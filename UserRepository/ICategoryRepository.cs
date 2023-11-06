using Entities.Models;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> getAllCategories();
    }
}