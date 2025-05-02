using UserService.Core.Models;

namespace UserService.Core.Abstractions
{
    public interface IUsersService
    {
        Task<Guid> CreateUser(User user);
        Task<Guid> DeleteUser(Guid userId);
        Task<List<User>> GetAllUsers();
        Task<Guid> UpdateUser(Guid userId, string name, string surename, string login, string contactNumber, string email, string password, List<Guid> ordersId);
    }
}