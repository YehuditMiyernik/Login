using Entities.Models;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}