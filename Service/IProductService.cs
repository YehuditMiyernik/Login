using Entities.Models;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}