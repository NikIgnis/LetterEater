using Microsoft.EntityFrameworkCore;
using OrderService.Core.Abstractions;
using OrderService.Core.Models;
using OrderService.DataAccess.Entities;

namespace OrderService.DataAccess.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly OrderDbContext _context;

        public CartItemRepository(OrderDbContext context)
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
                Quantity = cartItem.Quantity,
                Price = cartItem.Price,
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
                    c.Quantity,
                    c.Price
                ))
                .ToList();

            return cartItems;
        }

        public async Task<Guid> Update(Guid cartItemId, Guid userId, Guid bookId, int quantity, decimal price)
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