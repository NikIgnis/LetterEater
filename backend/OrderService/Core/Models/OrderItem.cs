﻿namespace OrderService.Core.Models
{
    public class OrderItem
    {
        private OrderItem(Guid orderItemId, Guid orderId, Guid bookId, int quantity, decimal price)
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
        public decimal Price { get; }

        public static OrderItem Create(Guid orderItemId, Guid orderId, Guid bookId, int quantity, decimal price)
        {
            return new OrderItem(orderItemId, orderId, bookId, quantity, price);
        }
    }
}
