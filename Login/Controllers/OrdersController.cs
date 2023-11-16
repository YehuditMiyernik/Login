using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MyFirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            try
            {
                Order ord = await _orderService.AddOrder(order);
                return CreatedAtAction(nameof(Get), new { id = ord.OrderId }, order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
