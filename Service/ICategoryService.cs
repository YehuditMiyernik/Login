using Entities.Models;

namespace Service
{
    public interface ICategoryService
    {
        Task<List<Category>> getAllCategories();
    }
}