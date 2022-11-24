using Doan.Interfaces;
using Doan.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory categoryService;

        public CategoriesController(ICategory categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return Ok(await categoryService.GetCategories());
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var Cat = await categoryService.GetCategory(id);
            return Cat == null ? NotFound() : Ok(Cat);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel model)
        {
            try
            {
                var newCat = await categoryService.AddCategory(model);
                var Cat = await categoryService.GetCategory(newCat);
                return Cat == null ? NotFound() : Ok(Cat);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryModel model)
        {
            if (id != model.ID) return NotFound();
            await categoryService.UpdateCategory(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
