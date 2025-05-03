using OrderService.Core.Abstractions;
using OrderService.Core.Models;

namespace OrderService.Application.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemsService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Guid> CreateCartItem(CartItem cartItem)
        {
            return await _cartItemRepository.Create(cartItem);
        }

        public async Task<List<CartItem>> GetAllCartItems()
        {
            return await _cartItemRepository.Get();
        }

        public async Task<Guid> UpdateCartItem(Guid cartItemId, Guid userId, Guid bookId, int quantity, decimal price)
        {
            return await _cartItemRepository.Update(cartItemId, userId, bookId, quantity, price);
        }

        public async Task<Guid> DeleteAllCartItems(Guid catItemId)
        {
            return await _cartItemRepository.Delete(catItemId);
        }
    }
}
