using LetterEater.Core.Models;

namespace LetterEater.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid bookId);
        Task<List<Book>> Get();
        Task<Guid> Update(Guid bookId, string title, string genre, string description, decimal price, int countPages, string series, string isbn, int quantity, Guid authorID, Guid publishingHouseId);
    }
}