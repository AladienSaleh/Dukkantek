using Dukkantek.Domain.Contracts.Manager;
using Dukkantek.Domain.Contracts.Provider;
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
        public async Task ChangeProductStatusAsync(Status productStatus)
        {
            await productProvider.ChangeProductStatusAsync(productStatus);
        }

        public async Task<int> GetProductCountByStatusAsync(Status productStatus)
        {
            return await productProvider.GetProductCountByStatusAsync(productStatus);
        }

        public async Task SellProductAsync(int productId)
        {
            await productProvider.SellProductAsync(productId);
        }
        #endregion
    }
}
