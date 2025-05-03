using CatalogService.Core.Abstractions;
using CatalogService.Core.Models;

namespace CatalogService.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _boolRepository;

        public BooksService(IBookRepository boolRepository)
        {
            _boolRepository = boolRepository;
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _boolRepository.Create(book);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _boolRepository.Get();
        }

        public async Task<Guid> UpdateBook(
            Guid bookId,
            string title,
            string authorName,
            int publicationYear,
            string genre,
            string description,
            decimal price,
            int countPages,
            string publishingHouseName,
            string series,
            string isbn,
            int quantity,
            Guid? authorId,
            Guid? publishingHouseID)
        {
            return await _boolRepository.Update(
                bookId,
                title,
                authorName,
                publicationYear,
                genre,
                description,
                price,
                countPages,
                publishingHouseName,
                series,
                isbn,
                quantity,
                authorId,
                publishingHouseID);
        }

        public async Task<Guid> DeleteBook(Guid bookId)
        {
            return await _boolRepository.Delete(bookId);
        }
    }
}