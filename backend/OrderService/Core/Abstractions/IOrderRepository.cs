using OrderService.Core.Models;

namespace OrderService.Core.Abstractions
{
    public interface IOrderRepository
    {
        Task<Guid> Create(Order order);
        Task<Guid> Delete(Guid orderId);
        Task<List<Order>> Get();
        Task<Guid> Update(Guid orderId, Guid userId, DateTime orderDate, List<Guid> orderItemsId);
    }
}