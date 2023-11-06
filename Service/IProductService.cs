using Entities.Models;

namespace Service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
    }
}