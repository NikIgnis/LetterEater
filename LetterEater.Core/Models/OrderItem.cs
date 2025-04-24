using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Core.Models
{
    public class OrderItem
    {
        private OrderItem(Guid orderItemId, Guid orderId, Guid bookId, int quantity, int price)
        {
            OrderItemId = orderItemId;
            OrderId = orderId;
            BookId = bookId;
            Quantity = quantity;
            Price = price;
        }

        public Guid OrderItemId { get; }
        public Guid OrderId { get; }
        public Guid BookId { get; }
        public int Quantity { get; }
        public int Price { get; }

        public static OrderItem Create(Guid orderItemId, Guid orderId, Guid bookId, int quantity, int price)
        {
            return new OrderItem(orderItemId, orderId, bookId, quantity, price);
        }
    }
}
