﻿namespace OrderService.Core.Models
{
    public class CartItem
    {
        private CartItem(Guid cartItemId, Guid userId, Guid bookId, int quantity, decimal price)
        {
            CartItemId = cartItemId;
            UserId = userId;
            BookId = bookId;
            Quantity = quantity;
            Price = price;
        }

        public Guid CartItemId { get; }
        public Guid UserId { get; }
        public Guid BookId { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public static CartItem Create(Guid cartItemId, Guid userId, Guid bookId, int quantity, decimal price)
        {
            return new CartItem(cartItemId, userId, bookId, quantity, price);
        }
    }
}