namespace OrderService.Core.Models
{
    public class Order
    {
        private Order(Guid orederId, Guid userId, DateTime orderDate, List<Guid> orderItemsId)
        {
            OrderId = orederId;
            UserId = userId;
            OrderDate = orderDate;
            OrderItemsId = new List<Guid>(orderItemsId);
        }

        public Guid OrderId { get; }
        public Guid UserId { get; }
        public DateTime OrderDate { get; }
        public List<Guid> OrderItemsId { get; }

        public static Order Create(Guid orederId, Guid userId, DateTime orderDate, List<Guid> orderItemsId)
        {
            return new Order(orederId, userId, orderDate, orderItemsId);
        }
    }
}