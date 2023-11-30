using Entities.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<Order> AddOrder(Order order)
    {
        order.OrderSum = CalculatePrice(order.OrderItems).Result;
        return await _orderRepository.AddOrder(order);
    }

    private async Task<int> CalculatePrice(IEnumerable<OrderItem> orderItems)
    {
        int price = 0;
        List<Product> products = await _productRepository.GetAllProducts();
        foreach (var item in orderItems)
        {
            Product prod = products.Find(p => p.Id == item.ProductId);
            if (prod != null)
            {
                price += prod.Price * item.Quantity;
            }
            //price += products.Find(p => p.Id == item.Id).Price * item.Quantity;
        }
        return price;

    }
}
