using System.ComponentModel.DataAnnotations;

namespace OrderService.DataAccess.Entities
{
    public class OrderItemEntity
    {
        [Key]
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderEntity? Order { get; set; }
    }
}