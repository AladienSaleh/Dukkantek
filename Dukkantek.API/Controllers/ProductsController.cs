using Dukkantek.API.ViewModel;
using Dukkantek.Domain.Pontracts.Manager;
using Dukkantek.Domain.Models;
using Dukkantek.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dukkantek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;

        public ProductsController(
            IProductManager productManager
            )
        {
            this.productManager = productManager;
        }

        [HttpGet]
        [Route("GetProductCountByStatus")]
        public async Task<ActionResult> GetProductCountByStatus(Status productStatus)
        {
            var count= await productManager.GetProductCountByStatusAsync(productStatus);

            return Ok(new { Status=productStatus , Count=count });
        }

        [HttpPost]
        [Route("ChangeProductStatusAsync")]
        public async Task<ActionResult> ChangeProductStatusAsync(ChangeProductStatusAsyncViewModel model)
        {
            await productManager.ChangeProductStatusAsync(model.ProductId, model.NewStatus);

            return Ok();
        }

        [HttpPost]
        [Route("SellProductAsync")]
        public async Task<ActionResult> SellProductAsync(int productId)
        {
            await productManager.SellProductAsync(productId);

            return Ok();
        }

        [HttpPost]
        [Route("AddProductForTest")]
        public async Task<ActionResult> AddProductForTest(AddProductForTestViewModel newProductViewModel)
        {
            ProductDomain newProduct=new ProductDomain()
            {
                Name=newProductViewModel.ProductName,
                Barcode=newProductViewModel.Barcode,
                Weight=newProductViewModel.Weight,
                Description=newProductViewModel.ProductDescription,
                Status=newProductViewModel.Status
            };
            CategoryDomain newCategory=new CategoryDomain()
            {
                Description=newProductViewModel.CategoryDescription,
                Name=newProductViewModel.CategoryName,  
            };

            newProduct = await productManager.AddProductForTest(newProduct,newCategory);

            return Ok(new { Product = newProduct });
        }

    }
}
