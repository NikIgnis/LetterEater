﻿using OrderService.Core.Abstractions;
using OrderService.Core.Models;

namespace OrderService.Application.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private readonly IOrderItemRepository _repositoryOrderItem;

        public OrderItemsService(IOrderItemRepository repositoryOrderItem)
        {
            _repositoryOrderItem = repositoryOrderItem;
        }

        public async Task<Guid> CreateOrderItem(OrderItem orderItem)
        {
            return await _repositoryOrderItem.Create(orderItem);
        }

        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            return await _repositoryOrderItem.Get();
        }

        public async Task<Guid> UpdateOrderItem(Guid orderItemId, Guid orderId, Guid bookId, int quantity, decimal price)
        {
            return await _repositoryOrderItem.Update(orderItemId, orderId, bookId, quantity, price);
        }

        public async Task<Guid> DeleteOrderItem(Guid orderItemId)
        {
            return await _repositoryOrderItem.Delete(orderItemId);
        }
    }
}