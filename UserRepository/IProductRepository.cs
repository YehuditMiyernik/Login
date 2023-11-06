using Entities.Models;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
    }
}