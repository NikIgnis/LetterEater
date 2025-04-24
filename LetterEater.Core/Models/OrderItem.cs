using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Core.Models
{
    public class OrderItem
    {
        private OrderItem(Guid orderItemId, Guid orderId, Guid bookId, int quantity, int price, Order order, Book book)
        {
            OrderItemId = orderItemId;
            OrderId = orderId;
            BookId = bookId;
            this.quantity = quantity;
            this.price = price;
            Order = order;
            Book = book;
        }

        public Guid OrderItemId { get; }
        public Guid OrderId { get; }
        public Guid BookId { get; }
        public int quantity { get; }
        public int price { get; }
        public Order Order { get; }
        public Book Book { get; }

        public static OrderItem Create(Guid orderItemId, Guid orderId, Guid bookId, int quantity, int price, Order order, Book book)
        {
            return new OrderItem(orderItemId, orderId, bookId, quantity, price, order, book);
        }
    }
}
