using Doan.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IProduct ProductService;

        public ProductController(IProduct db)
        {
            this.ProductService = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var q = await ProductService.GetAllProducts();
                return Ok(q);
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}
