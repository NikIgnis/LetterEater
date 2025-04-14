using LetterEater.Core.Models;

namespace LetterEater.Application.Services
{
    public interface IAuthorsService
    {
        Task<Guid> CreateAuthor(Author author);
        Task<Guid> DeleteAuthor(Guid authorId);
        Task<List<Author>> GetAllAuthors();
        Task<Guid> UpdateAuthor(Guid authorId, string name, string surename, List<Book> books);
    }
}