using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> getAllCategories();
    }
}