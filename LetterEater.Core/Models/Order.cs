namespace LetterEater.Core.Models
{
    public class Order
    {
        private Order(Guid orederId, Guid userId, DateTime orderDate, List<OrderItem> orderItems)
        {
            OrderId = orederId;
            UserId = userId;
            OrderDate = orderDate;
            OrderItems = new List<OrderItem>(orderItems);
        }

        public Guid OrderId { get; }
        public Guid UserId { get; }
        public DateTime OrderDate { get; }
        public List<OrderItem> OrderItems { get; }

        public static Order Create(Guid orederId, Guid userId, DateTime orderDate, List<OrderItem> orderItems)
        {
            return new Order(orederId, userId, orderDate, orderItems);
        }
    }
}