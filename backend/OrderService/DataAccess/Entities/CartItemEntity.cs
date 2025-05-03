using System.ComponentModel.DataAnnotations;

namespace OrderService.DataAccess.Entities
{
    public class CartItemEntity
    {
        [Key]
        public Guid CartItemId { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
     }
}
