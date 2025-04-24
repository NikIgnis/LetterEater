using LetterEater.Core.Models;

namespace LetterEater.Application.Services
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> DeleteUser(Guid userId);
        Task<List<User>> GetAllUsers();
        Task<Guid> UpdateUser(Guid userId, string name, string surename, string login, string contactNumber, string email, string password, List<Order> orders);
    }
}