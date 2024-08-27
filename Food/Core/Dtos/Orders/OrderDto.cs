using Core.Dtos.User;
using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.Orders
{
    public class OrderDto
    {
        public DateTime? OrderDate { get; set; }
        public required List<OrderItemDto> OrderItems { get; set; }
    }
    public class OrderItemDto
    {
        public required int MenuItemId { get; set; }
        [Required,Range(1,100)]
        public required int Quantity { get; set; }
    }
    public class UpdateStatus
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(0, 2)]
        public OrderStatus Status { get; set; }
    }
    public class ShowOrder
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public UserInfo? User { get; set; }
        public DateTime CreateAt { get; set; }
        public int? ModifierId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public List<ShowOrderItem>? OrderItems { get; set; }
    }
    public class ShowOrderItem
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public int? ModifierId { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
