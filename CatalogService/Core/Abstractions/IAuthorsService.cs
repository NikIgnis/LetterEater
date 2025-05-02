using CatalogService.Core.Models;

namespace CatalogService.Core.Abstractions
{
    public interface IAuthorsService
    {
        Task<Guid> CreateAuthor(Author author);
        Task<Guid> DeleteAuthor(Guid authorId);
        Task<List<Author>> GetAllAuthors();
        Task<Guid> UpdateAuthor(Guid authorId, string name, string surename, List<Guid> booksId);
    }
}