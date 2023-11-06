using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly Store325574630Context _Store325574630Context;
    public CategoryRepository()
    {
        _Store325574630Context = new Store325574630Context();
    }
    public async Task<List<Category>> getAllCategories()
    {
        return await _Store325574630Context.Categories.ToListAsync();
    }
}
