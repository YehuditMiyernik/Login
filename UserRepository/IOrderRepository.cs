using Entities.Models;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
    }
}