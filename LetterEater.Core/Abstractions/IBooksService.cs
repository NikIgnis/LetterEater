using LetterEater.Core.Models;

namespace LetterEater.Application.Services
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid bookId);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(
            Guid bookId,
            string title,
            string authorName,
            int publicationYear,
            string genre,
            string description,
            decimal price,
            int countPages,
            string publishingHouseName,
            string? series,
            string isbn,
            int quantity,
            Guid? authorId,
            Guid? publishingHouseID);
    }
}