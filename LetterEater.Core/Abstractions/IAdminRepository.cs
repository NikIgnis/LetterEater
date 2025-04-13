using LetterEater.Core.Models;

namespace LetterEater.DataAccess.Repositories
{
    public interface IAdminRepository
    {
        Task<Guid> Create(Admin admin);
        Task<Guid> Delete(Guid adminId);
        Task<List<Admin>> Get();
        Task<Guid> Update(Guid adminId, string name, string surename, string contactNumber, string email, string password);
    }
}