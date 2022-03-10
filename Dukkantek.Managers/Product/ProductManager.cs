using Dukkantek.Domain.Pontracts.Manager;
using Dukkantek.Domain.Pontracts.Provider;
using Dukkantek.Domain.Models;
using Dukkantek.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Managers.Product
{
    public class ProductManager : IProductManager
    {
        #region Private members
        private readonly IProductProvider productProvider;
        #endregion

        #region Constructor
        public ProductManager(
            IProductProvider productProvider
            )
        {
            this.productProvider = productProvider;
        }
        #endregion

        #region Public methods
        public async Task ChangeProductStatusAsync(int productId, Status newStatus)
        {
            await productProvider.ChangeProductStatusAsync(productId,newStatus);
        }

        public async Task<int> GetProductCountByStatusAsync(Status productStatus)
        {
            return await productProvider.GetProductCountByStatusAsync(productStatus);
        }

        public async Task SellProductAsync(int productId)
        {
            await productProvider.SellProductAsync(productId);
        }

        public async Task<ProductDomain> AddProductForTest(ProductDomain newProduct, CategoryDomain newCategory)
        {
            return await productProvider.AddProductForTest(newProduct, newCategory);
        }

        public async Task<(List<ProductDomain>, int)> GetProductList(int pageSize, int pageNumber)
        { 
            return await productProvider.GetProductList(pageSize, pageNumber);
        }
        #endregion
    }
}
