using Core.Dtos.Orders;
using Core.Entities;
using Core.Entities.Orders;
using Core.Enums;
using Core.Helper;
using Core.Interface.Auth;
using Core.Interface.Orders;
using Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly Responses _responses;
        private readonly ITokenData _tokenData;

        public OrderService(AppDbContext context, Responses responses, ITokenData tokenData)
        {
            _context = context;
            _responses = responses;
            _tokenData = tokenData;
        }
        public async Task<ActionResult> GetOrders()
        {
            try
            {
                var orders = await _context.Orders.Include(oi => oi.OrderItems).Include(u => u.User).ToListAsync();
                if (orders == null || !orders.Any())
                {
                    return _responses.ResponseNotFound("لا توجد طلبات للعرض!");
                }
                var showOrderList = orders.Adapt<List<ShowOrder>>();
                return _responses.ResponseSuccess("تم جلب الطلبات بنجاح.", showOrderList);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<ActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _context.Orders.Include(o => o.OrderItems).Include(u => u.User).FirstOrDefaultAsync(o => o.Id == id);
                if (order == null)
                {
                    return _responses.ResponseNotFound("معرف الطلب غير موجود .");
                }
                var showOrder = order.Adapt<ShowOrder>();

                return _responses.ResponseSuccess("تم جلب بيانات الطلب بنجاح.", showOrder);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<ActionResult> CreateOrder(OrderDto orderDto)
        {
            var UserId = _tokenData.UserId();
            try
            {
                var userExists = await _context.Users.AnyAsync(u => u.Id == UserId);
                if (!userExists)
                {
                    return _responses.ResponseBadRequest("المستخدم غير موجود.");
                }

                var order = new Order();
                order.OrderDate = orderDto.OrderDate ?? DateTime.UtcNow;
                order.CreateAt = DateTime.UtcNow;
                order.CreatorId = UserId;
                order.UserId = Convert.ToInt32(UserId);
                order.OrderItems = new List<OrderItem>();
                order.TotalAmount = 0;

                foreach (var itemDto in orderDto.OrderItems)
                {
                    var menuItem = await _context.MenuItems.FindAsync(itemDto.MenuItemId);
                    if (menuItem == null)
                    {
                        return _responses.ResponseBadRequest("لم يتم العثور على الوجبة");
                    }

                    var orderItem = itemDto.Adapt<OrderItem>();
                    orderItem.UnitPrice = menuItem.Price;

                    order.OrderItems.Add(orderItem);
                    order.TotalAmount += orderItem.UnitPrice * orderItem.Quantity;
                }

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                var showOrder = order.Adapt<ShowOrder>();
                return _responses.ResponseSuccess("تم إنشاء الطلب بنجاح.", showOrder);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<ActionResult> UpdateOrder(int id, OrderDto orderDto)
        {
            var UserId = _tokenData.UserId();
            try
            {
                var order = await _context.Orders.Include(o => o.OrderItems).Include(u => u.User).FirstOrDefaultAsync(o => o.Id == id);
                if (order == null)
                {
                    return _responses.ResponseNotFound("الطلب غير موجود.");
                }
                if (order.UserId != UserId)
                {
                    return _responses.ResponseBadRequest("لا تملك صلاحية لتعديل هذا الطلب");
                }
                if (order.Status == OrderStatus.InProgress || order.Status == OrderStatus.Completed)
                {
                    return _responses.ResponseBadRequest("لا يمكنك تعديل هذا الطلب بعد الان ");
                }
                _context.OrderItems.RemoveRange(order.OrderItems!);

                order.TotalAmount = 0;


                foreach (var itemDto in orderDto.OrderItems)
                {
                    var menuItem = await _context.MenuItems.FindAsync(itemDto.MenuItemId);
                    if (menuItem == null)
                    {
                        return _responses.ResponseBadRequest("لم يتم العثور على الوجبة");
                    }
                    var orderItem = itemDto.Adapt<OrderItem>();
                    orderItem.UnitPrice = menuItem.Price;
                    order.OrderItems!.Add(orderItem);
                    order.TotalAmount += orderItem.UnitPrice * orderItem.Quantity;
                }
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                var showOrder = order.Adapt<ShowOrder>();
                return _responses.ResponseSuccess("تم تحديث الطلب بنجاح.", showOrder);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<ActionResult> UpdateOrderStatus(UpdateStatus updateStatus)
        {
            try
            {
                var order = await _context.Orders.FindAsync(updateStatus.Id);
                if (order == null)
                {
                    return _responses.ResponseNotFound("الطلب غير موجود.");
                }

                order.Status = updateStatus.Status;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                return _responses.ResponseSuccess("تم تحديث حالة الطلب بنجاح.", order);
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                {
                    return _responses.ResponseNotFound("الطلب المطلوب غير موجود!");
                }
                var UserId = _tokenData.UserId();
                if (_tokenData.Role().ToString() != "SuperAdmin" || _tokenData.Role().ToString() != "Admin")
                {
                    if (order.UserId != UserId)
                    {
                        return _responses.ResponseBadRequest("لا تملك صلاحية لحذف هذا الطلب");
                    }
                    if (order.Status == OrderStatus.InProgress || order.Status == OrderStatus.Completed)
                    {
                        return _responses.ResponseBadRequest("لا يمكنك حذف هذا الطلب بعد الان ");
                    }
                }
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();

                return _responses.ResponseSuccess("تم حذف الطلب بنجاح.");
            }
            catch (DbUpdateException ex)
            {
                return _responses.DatebaseExaption(ex);
            }
            catch (Exception ex)
            {
                return _responses.HandleException(ex);
            }
        }

    }
}
