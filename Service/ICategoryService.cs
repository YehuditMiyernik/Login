using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Service
{
    public interface ICategoryService
    {
        Task<List<Category>> getAllCategories();
    }
}