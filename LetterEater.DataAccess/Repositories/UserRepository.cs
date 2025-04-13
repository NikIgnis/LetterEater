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
    public class UserRepository : IUserRepository
    {
        private readonly LetterEaterDbContext _context;

        public UserRepository(LetterEaterDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Create(Guid userId, string name, string surename, string login, string contactNumber, string email, string password)
        {
            bool userExist = await _context.Users.AnyAsync(u => u.UserId == userId);

            if (!userExist)
            {
                throw new Exception("User doesn't exist");
            }

            var userEntity = new UserEntity()
            {
                UserId = userId,
                Name = name,
                Surename = surename,
                Login = login,
                ContactNumber = contactNumber,
                Email = email,
                Password = password
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userId;
        }

        public async Task<List<User>> Get()
        {
            bool userExist = await _context.Users.AnyAsync();

            if (!userExist)
            {
                throw new Exception("Users doen't exist");
            }

            var userEntity = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntity
                .Select(a => User.Create(a.UserId, a.Name, a.Surename, a.Login, a.ContactNumber, a.Email, a.Password))
                .ToList();

            return users;
        }

        public async Task<Guid> Update(Guid userId, string name, string surename, string login, string contactNumber, string email, string password)
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