using LetterEater.Core.Models;
using LetterEater.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Application.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> CreateOrder(Order order)
        {
            return await _orderRepository.Create(order);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderRepository.Get();
        }

        public async Task<Guid> UpdateOrder(Guid orderId, Guid userId, DateTime orderDate, List<Guid> orderItemsId)
        {
            return await _orderRepository.Update(orderId, userId, orderDate, orderItemsId);
        }

        public async Task<Guid> DeleteOrder(Guid orderId)
        {
            return await _orderRepository.Delete(orderId);
        }
    }
}