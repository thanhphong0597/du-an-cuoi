using Doan.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralProducts : ControllerBase
    {
        private readonly IGeneralProduct generalProductService;

        public GeneralProducts(IGeneralProduct generalProductService)
        {
            this.generalProductService = generalProductService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGeneralProducts()
        {
            try
            {

                return Ok(await generalProductService.GetAllGeneralProducts());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
