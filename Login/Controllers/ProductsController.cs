using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;

        public ProductsController(IProductService productrService, IMapper mapper)
        {
            _productrService = productrService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> list = await _productrService.GetAllProducts(desc, minPrice, maxPrice, categoryIds);
            List<ProductDTO> productDTOs = _mapper.Map< List<Product>, List<ProductDTO>>(list);
            if (list == null)
                return NoContent();
            return Ok(productDTOs);
        }
    }
}
