using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class OrderRepository : IOrderRepository
{
    private readonly Store325574630Context _Store325574630Context;
    public OrderRepository()
    {
        _Store325574630Context = new Store325574630Context();
    }

    public async Task<Order> AddOrder(Order order)
    {
        await _Store325574630Context.Orders.AddAsync(order);
        await _Store325574630Context.SaveChangesAsync();
        return order;
    }
}
