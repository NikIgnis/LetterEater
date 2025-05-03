using Microsoft.EntityFrameworkCore;
using OrderService.DataAccess.Entities;

namespace OrderService.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<CartItemEntity> CartItems { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<OrderEntity> Orders{ get; set; }
    }
}