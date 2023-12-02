using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        } 

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] OrderDTO order)
        {
            try
            {
                Order o = _mapper.Map<OrderDTO,Order>(order);
                Order newOrder = await _orderService.AddOrder(o);
                OrderDTO newOrderDTO = _mapper.Map<Order, OrderDTO>(newOrder);
                return CreatedAtAction(nameof(Post), new { id = newOrder.OrderId }, newOrderDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
