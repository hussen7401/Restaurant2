using Core.Dtos.Orders;
using Core.Interface.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            return await _orderService.GetOrders();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            return await _orderService.GetOrderById(id);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            return await _orderService.CreateOrder(orderDto);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateOrder(int id, [FromBody] OrderDto orderDto)
        {
            return await _orderService.UpdateOrder(id, orderDto);
        }

        [HttpPut("update-status")]
        public async Task<ActionResult> UpdateOrderStatus([FromBody] UpdateStatus updateStatus)
        {
            return await _orderService.UpdateOrderStatus(updateStatus);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            return await _orderService.DeleteOrder(id);
        }
    }
}
