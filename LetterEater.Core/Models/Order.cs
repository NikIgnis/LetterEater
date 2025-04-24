namespace LetterEater.Core.Models
{
    public class Order
    {
        private Order(Guid orederId, Guid userId, DateTime orderDate, List<OrderItem> orderItems, User user)
        {
            OrderId = orederId;
            UserId = userId;
            OrderDate = orderDate;
            OrderItems = new List<OrderItem>(orderItems);
            User = user;
        }

        public Guid OrderId { get; }
        public Guid UserId { get; }
        public DateTime OrderDate { get; }
        public List<OrderItem> OrderItems { get; }
        public User User { get; }

        public static Order Create(Guid orederId, Guid userId, DateTime orderDate, List<OrderItem> orderItems, User user)
        {
            return new Order(orederId, userId, orderDate, orderItems, user);
        }
    }
}