using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly Store325574630Context _Store325574630Context;
        public OrderItemRepository()
        {
            _Store325574630Context = new Store325574630Context();
        }
        public async Task AddOrderItems(OrderItem[] orederItems)
        {
            foreach (var item in orederItems)
            {
                await _Store325574630Context.OrderItems.AddAsync(item);
                await _Store325574630Context.SaveChangesAsync();
            }
            return;
        }
    }
}
