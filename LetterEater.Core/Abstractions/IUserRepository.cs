using LetterEater.Core.Models;

namespace LetterEater.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> Create(Guid userId, string name, string surename, string login, string contactNumber, string email, string password);
        Task<Guid> Delete(Guid userId);
        Task<List<User>> Get();
        Task<Guid> Update(Guid userId, string name, string surename, string login, string contactNumber, string email, string password);
    }
}