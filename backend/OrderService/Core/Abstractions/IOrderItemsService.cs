using OrderService.Core.Models;

namespace OrderService.Core.Abstractions
{
    public interface IOrderItemsService
    {
        Task<Guid> CreateOrderItem(OrderItem orderItem);
        Task<Guid> DeleteOrderItem(Guid orderItemId);
        Task<List<OrderItem>> GetAllOrderItems();
        Task<Guid> UpdateOrderItem(Guid orderItemId, Guid orderId, Guid bookId, int quantity, decimal price);
    }
}