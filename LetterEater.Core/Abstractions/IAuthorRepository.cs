using LetterEater.Core.Models;

namespace LetterEater.DataAccess.Repositories
{
    public interface IAuthorRepository
    {
        Task<Guid> Create(Author author);
        Task<Guid> Delete(Guid authorId);
        Task<List<Author>> Get();
        Task<Guid> Update(Guid authorId, string name, string surename, List<Book> books);
    }
}