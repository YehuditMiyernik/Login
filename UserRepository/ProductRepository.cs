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
    public async Task<List<Product>> GetAllProducts(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
    {
        var query = _Store325574630Context.Products.Where(product =>
        (desc == null ? (true) : (product.Description.Contains(desc)))
        && ((minPrice == null) ? (true) : (product.Price >= minPrice))
        && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
        && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
            .OrderBy(Product => Product.Price);
        Console.WriteLine(query.ToQueryString());
        List<Product> products = await query.ToListAsync();
        return products;
    }
}
