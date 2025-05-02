using Microsoft.EntityFrameworkCore;
using UserService.Core.Abstractions;
using UserService.Core.Models;
using UserService.DataAccess.Entities;

namespace UserService.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
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
                Password = user.Password,
                OrdersId = new List<Guid>(user.OrdersId)
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
                    a.OrdersId
                ))
                .ToList();

            return users;
        }

        public async Task<Guid> Update(Guid userId, string name, string surename, string login, string contactNumber, string email, string password, List<Guid> ordersId)
        {
            bool userExist = await _context.Users.AnyAsync(u => u.UserId == userId);

            if (!userExist)
            {
                throw new Exception("User doesn't exist");
            }

            await _context.Users
                .Where(b => b.UserId == userId)
                .ExecuteUpdateAsync(b => b
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Surename, b => surename)
                    .SetProperty(b => b.Login, b => login)
                    .SetProperty(b => b.ContactNumber, b => contactNumber)
                    .SetProperty(b => b.Email, b => email)
                    .SetProperty(b => b.Password, b => password)
                    .SetProperty(b => b.OrdersId, b => ordersId));

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