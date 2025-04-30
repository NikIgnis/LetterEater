using LetterEater.Core.Models;

namespace LetterEater.DataAccess.Repositories
{
    public interface IOrderRepository
    {
        Task<Guid> Create(Order order);
        Task<Guid> Delete(Guid orderId);
        Task<List<Order>> Get();
        Task<Guid> Update(Guid orderId, Guid userId, DateTime orderDate, List<OrderItem> orderItems);
    }
}