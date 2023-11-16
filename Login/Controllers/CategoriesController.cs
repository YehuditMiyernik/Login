using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> list = await _categoryService.getAllCategories();
            if (list == null)
                return NoContent();
            return Ok(list);
        }
    }
}
