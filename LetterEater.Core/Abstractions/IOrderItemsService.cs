using LetterEater.Core.Models;

namespace LetterEater.Application.Services
{
    public interface IOrderItemsService
    {
        Task<Guid> CreateOrderItem(OrderItem orderItem);
        Task<Guid> DeleteOrderItem(Guid orderItemId);
        Task<List<OrderItem>> Get();
        Task<Guid> UpdateOrderItem(Guid orderItemId, Guid orderId, Guid bookId, int quantity, decimal price);
    }
}