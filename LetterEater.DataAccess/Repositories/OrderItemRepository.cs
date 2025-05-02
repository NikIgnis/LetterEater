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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly LetterEaterDbContext _context;

        public OrderItemRepository(LetterEaterDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(OrderItem orderItem)
        {
            bool orderItemExist = await _context.OrderItems.AnyAsync(oi => oi.OrderItemId == orderItem.OrderId);

            if (orderItemExist)
            {
                throw new Exception("This order item is already exist!");
            }

            var orderIremEntity = new OrderItemEntity()
            {
                OrderItemId = orderItem.OrderId,
                OrderId = orderItem.OrderId,
                BookId = orderItem.BookId,
                Quantity = orderItem.Quantity,
                Price = orderItem.Price,
            };

            await _context.AddAsync(orderIremEntity);
            await _context.SaveChangesAsync();

            return orderItem.OrderItemId;
        }

        public async Task<List<OrderItem>> Get()
        {
            var orderItemEntity = await _context.OrderItems
                .AsNoTracking()
                .ToListAsync();

            var orderItems = orderItemEntity
                .Select(oi => OrderItem.Create(
                    oi.OrderItemId,
                    oi.OrderId,
                    oi.BookId,
                    oi.Quantity,
                    oi.Price
                ))
                .ToList();

            return orderItems;
        }

        public async Task<Guid> Update(Guid orderItemId, Guid orderId, Guid bookId, int quantity, decimal price)
        {
            bool orderItemExist = await _context.OrderItems.AnyAsync(oi => oi.OrderItemId == orderItemId);

            if (!orderItemExist)
            {
                throw new Exception("Order item doesn't exist!");
            }

            await _context.OrderItems
                .Where(oi => oi.OrderItemId == orderItemId)
                .ExecuteUpdateAsync(oi => oi
                    .SetProperty(oi => oi.OrderId, b => orderId)
                    .SetProperty(oi => oi.BookId, b => bookId)
                    .SetProperty(oi => oi.Quantity, b => quantity)
                    .SetProperty(oi => oi.Price, b => price)
                );

            return orderItemId;
        }

        public async Task<Guid> Delete(Guid orderItemId)
        {
            bool orderItemExist = await _context.OrderItems.AnyAsync(oi => oi.OrderItemId == orderItemId);

            if (!orderItemExist)
            {
                throw new Exception("Order item doesn't exist!");
            }

            await _context.OrderItems
                .Where(oi => oi.OrderItemId == orderItemId)
                .ExecuteDeleteAsync();

            return orderItemId;
        }
    }
}