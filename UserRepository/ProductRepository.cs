using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class ProductRepository : IProductRepository
{
    private readonly Store325574630Context _Store325574630Context;
    public ProductRepository()
    {
        _Store325574630Context = new Store325574630Context();
    }
    public async Task<List<Product>> GetAllProducts()
    {
        return await _Store325574630Context.Products.ToListAsync();
    }
}
