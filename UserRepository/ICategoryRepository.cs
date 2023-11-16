using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> getAllCategories();
    }
}