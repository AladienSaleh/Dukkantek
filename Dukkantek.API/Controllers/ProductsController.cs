using Dukkantek.Domain.Contracts.Manager;
using Dukkantek.Shared.Enums;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [Route("GetProductCountByStatus")]
        public async Task<ActionResult> ChangeProductStatusAsync(Status productStatus)
        {
            await productManager.ChangeProductStatusAsync(productStatus);

            return Ok();
        }

        [HttpGet]
        [Route("GetProductCountByStatus")]
        public async Task<ActionResult> GetProductCountByStatus(int productId)
        {
            await productManager.SellProductAsync(productId);

            return Ok();
        }


    }
}
