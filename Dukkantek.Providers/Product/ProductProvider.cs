using AutoMapper;
using Dukkantek.Data.Models;
using Dukkantek.Data.Models.Products;
using Dukkantek.Domain.Pontracts.Provider;
using Dukkantek.Domain.Models;
using Dukkantek.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dukkantek.Shared.Exceptions;

namespace Dukkantek.Providers.Products
{
    public class ProductProvider : IProductProvider
    {
        #region Private members
        private readonly DukkantekApiDbContext dbContext;
        private readonly IMapper mapper;
        #endregion

        #region Constructor
        public ProductProvider(
            DukkantekApiDbContext dbContext,
            IMapper mapper
            )
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        #endregion

        #region Public methods
        public async Task ChangeProductStatusAsync(int productId, Status newStatus)
        {
            var product = await dbContext.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();
            if (product == null)
            {
                throw new AppException($"Product {productId} not found");
            }
            product.Status = newStatus;
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> GetProductCountByStatusAsync(Status productStatus)
        {
            return await dbContext.Products.Where(p => p.Status == productStatus).CountAsync();
        }

        public async Task SellProductAsync(int productId)
        {
            var product = await dbContext.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                throw new AppException($"Product {productId} not found");
            }

            product.Status = Status.Sold;
            await dbContext.SaveChangesAsync();
        }

        public async Task<ProductDomain> AddProductForTest(ProductDomain newProduct, CategoryDomain newCategory)
        {
            var product = mapper.Map<Product>(newProduct);
            dbContext.Products.Add(product);

            Category category = await dbContext.Categories.Where(c => c.Name.ToLower().Equals(newCategory.Name.ToLower()))
                .FirstOrDefaultAsync();
            if (category == null)
            {
                category = mapper.Map<Category>(newCategory);
                dbContext.Categories.Add(category);
            }
            await dbContext.SaveChangesAsync();

            dbContext.ProductCategories.Add(new ProductCategory()
            {
                Category = category,
                Product = product
            });
            await dbContext.SaveChangesAsync();

            return mapper.Map<ProductDomain>(product);
        }

        public async Task<(List<ProductDomain>, int)> GetProductList(int pageSize, int pageNumber)
        {
            if (pageSize < 0 || pageNumber < 0)
            {
                throw new AppException($"parameter can't be negative (pageSize:{pageSize}, pageNumber:{pageNumber})");
            }
            var query = dbContext.Products
                .Include(p => p.ProductCategory)
                    .ThenInclude(pc => pc.Category)
                .OrderBy(p => p.Id)
                .AsSplitQuery()
                .AsNoTracking();

            var totalCount = await query.CountAsync();
            if (pageNumber >= 0 && pageSize > 0)
            {
                query = query.Skip(pageSize * pageNumber).Take(pageSize);
            }
            var products = await query.ToListAsync();

            return (mapper.Map<List<ProductDomain>>(products), totalCount);
        }
        #endregion
    }
}
