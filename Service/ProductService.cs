using Entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> GetAllProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
    {
        return await _productRepository.GetAllProducts(position, skip, desc, minPrice, maxPrice, categoryIds);
    }
}
