using Entities.Models;

namespace Services
{
    public interface IOrderItemService
    {
        Task AddOrderItems(OrderItem[] orderItems);
    }
}