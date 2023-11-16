using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productrService;

        public ProductsController(IProductService productrService)
        {
            _productrService = productrService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> list = await _productrService.GetAllProducts(desc, minPrice, maxPrice, categoryIds);
            if (list == null)
                return NoContent();
            return Ok(list);
        }
    }
}
