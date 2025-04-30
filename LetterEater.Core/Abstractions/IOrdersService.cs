using LetterEater.Core.Models;

namespace LetterEater.Application.Services
{
    public interface IOrdersService
    {
        Task<Guid> CreateOrder(Order order);
        Task<Guid> DeleteOrder(Guid orderId);
        Task<List<Order>> GetAllOrders();
        Task<Guid> UpdateOrder(Guid orderId, Guid userId, DateTime orderDate, List<OrderItem> orderItems);
    }
}