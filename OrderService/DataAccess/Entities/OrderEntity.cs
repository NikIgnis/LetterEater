using System.ComponentModel.DataAnnotations;

namespace OrderService.DataAccess.Entities
{
    public class OrderEntity
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<Guid>? OrderItemsId { get; set; } = new List<Guid>();

        //Dependencies
        public List<OrderItemEntity> OrderItems { get; set; }
    }
}