using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Core.Models
{
    public class CartItem
    {
        private CartItem(Guid cartItemId, Guid userId, Guid bookId, Book book, int quantity, int price)
        {
            CartItemId = cartItemId;
            UserId = userId;
            BookId = bookId;
            Book = book;
            Quantity = quantity;
            Price = price;
        }

        public Guid CartItemId { get; }
        public Guid UserId { get; }
        public Guid BookId { get; }
        public Book Book { get; }
        public int Quantity { get; }
        public decimal Price { get; }

        public static CartItem Create(Guid cartItemId, Guid userId, Guid bookId, Book book, int quantity, int price)
        {
            return new CartItem(cartItemId, userId, bookId, book, quantity, price);
        }
    }
}