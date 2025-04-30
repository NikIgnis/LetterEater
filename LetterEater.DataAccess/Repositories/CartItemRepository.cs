using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly LetterEaterDbContext _context;

        public CartItemRepository(LetterEaterDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CartItem cartItem)
        {

            bool cartItemExist = await _context.CartItems.AnyAsync(ci => ci.CartItemId == cartItem.BookId);

            if (cartItemExist)
            {
                throw new Exception("This cart item is already available!");
            }

            var cartItemEntity = new CartItemEntity
            {
                CartItemId = cartItem.CartItemId,
                UserId = cartItem.UserId,
                BookId = cartItem.BookId,
                Book = new BookEntity 
                {
                    BookId = cartItem.Book.BookId,
                    Title = cartItem.Book.Title,
                    Genre = cartItem.Book.Genre,
                    Description = cartItem.Book.Description,
                    Price = cartItem.Book.Price,
                    CountPages = cartItem.Book.CountPages,
                    Series = cartItem.Book.Series,
                    ISBN = cartItem.Book.ISBN,
                    Quantity = cartItem.Book.Quantity,
                    AuthorId = cartItem.Book.AuthorId,
                    PublishingHouseId = cartItem.Book.PublishingHouseId
                },
                Quantity = cartItem.Quantity,
                Price = cartItem.Price
            };

            await _context.CartItems.AddAsync(cartItemEntity);

            await _context.SaveChangesAsync();

            return cartItemEntity.CartItemId;
        }

        public async Task<List<CartItem>> Get()
        {
            var cartItemEntity = await _context.CartItems
                .AsNoTracking()
                .ToListAsync();

            var cartItems = cartItemEntity
                .Select(c => CartItem.Create(
                    c.CartItemId,
                    c.UserId,
                    c.BookId,
                    Book.Create(
                        c.Book.BookId,
                        c.Book.Title,
                        c.Book.AuthorName,
                        c.Book.PublicationYear,
                        c.Book.Genre,
                        c.Book.Description,
                        c.Book.Price,
                        c.Book.CountPages,
                        c.Book.PublishingHouseName,
                        c.Book.Series,
                        c.Book.ISBN,
                        c.Book.Quantity,
                        c.Book.AuthorId,
                        c.Book.PublishingHouseId
                    ),
                    c.Quantity,
                    c.Price
                ))
                .ToList();

            return cartItems;
        }

        public async Task<Guid> Update(Guid cartItemId, Guid userId, Guid bookId, Book book, int quantity, decimal price)
        {
            bool cartItemExist = await _context.CartItems.AnyAsync(ci => ci.CartItemId == cartItemId);

            if (!cartItemExist)
            {
                throw new Exception("CartItem doesn't exist");
            }

            await _context.CartItems
                .Where(ci => ci.CartItemId == cartItemId)
                .ExecuteUpdateAsync(ci => ci
                    .SetProperty(ci => ci.UserId, ci => userId)
                    .SetProperty(ci => ci.BookId, ci => bookId)
                    .SetProperty(ci => ci.Quantity, ci => quantity)
                    .SetProperty(ci => ci.Price, ci => price));

            var cartItem = await _context.CartItems
                .Include(ci => ci.CartItemId)
                .FirstOrDefaultAsync();

            cartItem.Book = new BookEntity
            {
                BookId = book.BookId,
                Title = book.Title,
                Genre = book.Genre,
                Description = book.Description,
                Price = book.Price,
                CountPages = book.CountPages,
                Series = book.Series,
                ISBN = book.ISBN,
                Quantity = book.Quantity,
                AuthorId = book.AuthorId,
                PublishingHouseId = book.PublishingHouseId
            };

            await _context.SaveChangesAsync();

            return cartItemId;
        }

        public async Task<Guid> Delete(Guid cartItemId)
        {
            bool cartItemExist = await _context.CartItems.AnyAsync(ci => ci.CartItemId == cartItemId);

            if (!cartItemExist)
            {
                throw new Exception("CartItem doesn't exist");
            }

            await _context.CartItems
                .Where(ci => ci.CartItemId == cartItemId)
                .ExecuteDeleteAsync();

            return cartItemId;
        }
    }
}