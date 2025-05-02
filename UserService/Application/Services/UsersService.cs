using UserService.Core.Abstractions;
using UserService.Core.Models;

namespace UserService.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> CreateUser(User user)
        {
            return await _userRepository.Create(user);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.Get();
        }

        public async Task<Guid> UpdateUser(Guid userId, string name, string surename, string login, string contactNumber, string email, string password, List<Guid> ordersId)
        {
            return await _userRepository.Update(userId, name, surename, login, contactNumber, email, password, ordersId);
        }

        public async Task<Guid> DeleteUser(Guid userId)
        {
            return await _userRepository.Delete(userId);
        }
    }
}