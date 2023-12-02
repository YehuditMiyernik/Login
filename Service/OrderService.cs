using Entities.Models;
using Microsoft.Extensions.Logging;
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
    private readonly ILogger<OrderService> _logger;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Order> AddOrder(Order order)
    {
        int price = CalculatePrice(order.OrderItems).Result;
        if(order.OrderSum != price)
        {
            _logger.LogInformation($"user {order.UserId} tried to steal");
            order.OrderSum = price;
        }
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
        }
        return price;

    }
}
