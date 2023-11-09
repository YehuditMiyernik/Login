﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> list = await _productrService.GetAllProducts();
            if (list == null)
                return NoContent();
            return Ok(list);
        }
    }
}