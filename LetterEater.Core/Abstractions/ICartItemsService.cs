using LetterEater.Core.Models;

namespace LetterEater.Application.Services
{
    public interface ICartItemsService
    {
        Task<Guid> CreateCartItem(CartItem cartItem);
        Task<Guid> DeleteAllCartItems(Guid catItemId);
        Task<List<CartItem>> GetAllCartItems();
        Task<Guid> UpdateCartItem(Guid cartItemId, Guid userId, Guid bookId, int quantity, decimal price);
    }
}