using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LetterEater.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LetterEaterDbContext _context;

        public UserRepository(LetterEaterDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(User user)
        {
            var userEntity = new UserEntity()
            {
                UserId = user.UserId,
                Name = user.Name,
                Surename = user.Surename,
                Login = user.Login,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
                Password = user.Password
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return user.UserId;
        }

        public async Task<List<User>> Get()
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntity
                .Select(a => User.Create(
                    a.UserId,
                    a.Name,
                    a.Surename,
                    a.Login,
                    a.ContactNumber,
                    a.Email,
                    a.Password,
                    a.Orders.Select(orderEntity => Order.Create(
                        orderEntity.OrderId,
                        orderEntity.UserId,
                        orderEntity.OrderDate,
                        orderEntity.OrderItems.Select(o => OrderItem.Create(
                            o.OrderItemId,
                            o.OrderId,
                            o.BookId,
                            o.Quantity,
                            o.Price
                            ))
                        .ToList()
                    ))
                    .ToList()
                ))
                .ToList();

            return users;
        }

        public async Task<Guid> Update(Guid userId, string name, string surename, string login, string contactNumber, string email, string password, List<Order> orders)
        {
            bool userExist = await _context.Users.AnyAsync(u => u.UserId == userId);

            if (!userExist)
            {
                throw new Exception("User doesn't exist");
            }

            await _context.Users
                .Where(b => b.UserId == userId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Surename, b => surename)
                    .SetProperty(b => b.Login, b => login)
                    .SetProperty(b => b.ContactNumber, b => contactNumber)
                    .SetProperty(b => b.Email, b => email)
                    .SetProperty(b => b.Password, b => password));

            var user = await _context.Users
                .Include(u => u.UserId)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user.Orders.Clear();

            foreach(var order in orders)
            {
                var orderEntities = orders.Select(order => new OrderEntity
                {
                    OrderId = order.OrderId,
                    UserId = userId,
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderItems.Select(item => new OrderItemEntity
                    {
                        OrderItemId = item.OrderItemId,
                        OrderId = item.OrderId,
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    }).ToList()
                }).ToList();
            }

            return userId;
        }

        public async Task<Guid> Delete(Guid userId)
        {
            bool userExist = await _context.Users.AnyAsync(u => u.UserId == userId);

            if (!userExist)
            {
                throw new Exception("User doesn't exist");
            }

            await _context.Users
                .Where(b => b.UserId == userId)
                .ExecuteDeleteAsync();

            return userId;
        }
    }
}