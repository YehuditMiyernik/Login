using Entities.Models;

namespace Repositories
{
    public interface IOrderItemRepository
    {
        Task AddOrderItems(OrderItem[] orederItems);
    }
}