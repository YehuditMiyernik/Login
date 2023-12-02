using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly Store325574630Context _Store325574630Context;
    public OrderRepository(Store325574630Context store325574630Context)
    {
        _Store325574630Context = store325574630Context;
    }

    public async Task<Order> AddOrder(Order order)
    {
        await _Store325574630Context.Orders.AddAsync(order);
        await _Store325574630Context.SaveChangesAsync();
        return order;
    }
}
