using Entities.Models;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}