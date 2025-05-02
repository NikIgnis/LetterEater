using CatalogService.Core.Models;

namespace CatalogService.Core.Abstractions
{
    public interface IAuthorRepository
    {
        Task<Guid> Create(Author author);
        Task<Guid> Delete(Guid authorId);
        Task<List<Author>> Get();
        Task<Guid> Update(Guid authorId, string name, string surename, List<Guid> booksId);
    }
}