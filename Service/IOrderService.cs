using Entities.Models;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
    }
}