using AutoMapper;
using Dukkantek.Data.Models;
using Dukkantek.Data.Models.Products;
using Dukkantek.Domain.Pontracts.Provider;
using Dukkantek.Domain.Models;
using Dukkantek.Shared.Enums;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using System.Threading.Tasks;

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
                Category=category,
                Product=product
            });
            await dbContext.SaveChangesAsync();

            return mapper.Map<ProductDomain>(product);
        }
        #endregion
    }
}
