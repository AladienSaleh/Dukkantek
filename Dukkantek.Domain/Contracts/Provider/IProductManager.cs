using Dukkantek.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Contracts.Provider
{
    public interface IProductProvider
    {
        Task<int> GetProductCountByStatusAsync(Status productStatus);

        Task ChangeProductStatusAsync(Status productStatus);

        Task SellProductAsync(int productId);
    }
}
