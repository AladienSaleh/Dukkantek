using Dukkantek.Domain.Models;
using Dukkantek.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dukkantek.Domain.Pontracts.Provider
{
    public interface IProductProvider
    {
        Task<int> GetProductCountByStatusAsync(Status productStatus);

        Task ChangeProductStatusAsync(int productId, Status newStatus);

        Task SellProductAsync(int productId);

        Task<ProductDomain> AddProductForTest(ProductDomain newProduct, CategoryDomain newCategory);

        Task<(List<ProductDomain>, int)> GetProductList(int pageSize, int pageNumber);
    }
}
