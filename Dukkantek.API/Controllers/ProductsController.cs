using Dukkantek.API.ViewModel;
using Dukkantek.Domain.Pontracts.Manager;
using Dukkantek.Domain.Models;
using Dukkantek.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Dukkantek.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly ILogger<ProductsController> logger;

        public ProductsController(
            IProductManager productManager,
            ILogger<ProductsController> logger
            )
        {
            this.productManager = productManager;
            this.logger = logger;
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
            logger.LogInformation("Test");
            logger.LogError("Test");
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

        [HttpGet]
        [Route("GetProductList")]
        public async Task<ActionResult> GetProductList(int pageSize=0, int pageNumber=0)
        {
            var ( ProductList,TotalCount) = await productManager.GetProductList(pageSize, pageNumber);

            return Ok(new { ProductList, TotalCount });
        }

    }
}
