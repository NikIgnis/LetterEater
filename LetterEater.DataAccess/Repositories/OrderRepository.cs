using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LetterEaterDbContext _context;

        public OrderRepository(LetterEaterDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Order order)
        {
            bool orderExist = await _context.Orders.AnyAsync(o => o.OrderId == order.OrderId);

            if (orderExist)
            {
                throw new Exception("This order is already available!");
            }

            var orderEntity = new OrderEntity
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                OrderItemsId = new List<Guid>(order.OrderItemsId)
            };

            await _context.Orders.AddAsync(orderEntity);

            await _context.SaveChangesAsync();

            return orderEntity.OrderId;
        }

        public async Task<List<Order>> Get()
        {
            var orderEntities = await _context.Orders
                .AsNoTracking()
                .ToListAsync();

            var orders = orderEntities
                .Select(a => Order.Create(
                    a.OrderId,
                    a.UserId,
                    a.OrderDate,
                    a.OrderItemsId
                ))
                .ToList();

            return orders;
        }

        public async Task<Guid> Update(Guid orderId, Guid userId, DateTime orderDate, List<Guid> orderItemsId)
        {
            bool orderExist = await _context.Orders.AnyAsync(o => o.OrderId == orderId);

            if (!orderExist)
            {
                throw new Exception("Order doesn't exist!");
            }

            await _context.Orders
                .Where(oi => oi.OrderId == orderId)
                .ExecuteUpdateAsync(oi => oi
                    .SetProperty(oi => oi.UserId, oi => userId)
                    .SetProperty(oi => oi.OrderDate, oi => orderDate)
                    .SetProperty(oi => oi.OrderItemsId, new List<Guid>(orderItemsId)));

            return orderId;
        }

        public async Task<Guid> Delete(Guid orderId)
        {
            bool orderExist = await _context.Orders.AnyAsync(o => o.OrderId == orderId);

            if (!orderExist)
            {
                throw new Exception("Order doesn't exist!");
            }

            await _context.Orders
                .Where(o => o.OrderId == orderId)
                .ExecuteDeleteAsync();

            return orderId;
        }
    }
}