﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryService)
    {
        _categoryRepository = categoryService;
    }
    public async Task<List<Category>> getAllCategories()
    {
        return await _categoryRepository.getAllCategories();
    }
}
