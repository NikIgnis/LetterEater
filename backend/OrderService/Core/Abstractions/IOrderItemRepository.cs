using OrderService.Core.Models;

namespace OrderService.Core.Abstractions
{
    public interface IOrderItemRepository
    {
        Task<Guid> Create(OrderItem orderItem);
        Task<Guid> Delete(Guid orderItemId);
        Task<List<OrderItem>> Get();
        Task<Guid> Update(Guid orderItemId, Guid orderId, Guid bookId, int quantity, decimal price);
    }
}