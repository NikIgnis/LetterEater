using LetterEater.Core.Models;

namespace LetterEater.DataAccess.Repositories
{
    public interface ICartItemRepository
    {
        Task<Guid> Create(CartItem cartItem);
        Task<Guid> Delete(Guid cartItemId);
        Task<List<CartItem>> Get();
        Task<Guid> Update(Guid cartItemId, Guid userId, Guid bookId, int quantity, decimal price);
    }
}