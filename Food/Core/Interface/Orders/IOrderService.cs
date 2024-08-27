using Core.Dtos.Orders;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interface.Orders
{
    public interface IOrderService
    {
        Task<ActionResult> GetOrders();
        Task<ActionResult> GetOrderById(int id);
        Task<ActionResult> CreateOrder(OrderDto orderDto);
        Task<ActionResult> UpdateOrder(int id, OrderDto orderDto);
        Task<ActionResult> UpdateOrderStatus(UpdateStatus updateStatus);
        Task<ActionResult> DeleteOrder(int id);
    }
}
