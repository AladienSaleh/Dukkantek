using Dukkantek.Domain.Contracts.Provider;
using Dukkantek.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Providers.Product
{
    public class ProductProvider : IProductProvider
    {
        public async Task ChangeProductStatusAsync(Status productStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetProductCountByStatusAsync(Status productStatus)
        {
            throw new NotImplementedException();
        }

        public async Task SellProductAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
