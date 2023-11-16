using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface ICategoryService
    {
        Task<List<Category>> getAllCategories();
    }
}