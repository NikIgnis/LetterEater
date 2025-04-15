using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LetterEater.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LetterEaterDbContext _context;

        public BookRepository(LetterEaterDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Book book)
        {
            bool bookExist = await _context.Books.AnyAsync(b => b.BookId == book.BookId);

            if (bookExist)
            {
                throw new Exception("This book is already available!");
            }

            var bookEntity = new BookEntity
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = book.AuthorName,
                PublicationYear = book.PublicationYear,
                Genre = book.Genre,
                Description = book.Description,
                Price = book.Price,
                CountPages = book.CountPages,
                PublishingHouseName = book.PublishingHouseName,
                Series = book.Series,
                ISBN = book.ISBN,
                Quantity = book.Quantity,
                AuthorId = book.AuthorId,
                PublishingHouseId = book.PublishingHouseId
            };

            await _context.Books.AddAsync(bookEntity);

            await _context.SaveChangesAsync();

            return bookEntity.BookId;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities
                .Select(b => Book.Create(
                    b.BookId,
                    b.Title,
                    b.AuthorName,
                    b.PublicationYear,
                    b.Genre,
                    b.Description,
                    b.Price,
                    b.CountPages,
                    b.PublishingHouseName,
                    b.Series,
                    b.ISBN,
                    b.Quantity,
                    b.AuthorId,
                    b.PublishingHouseId))
                .ToList();

            return books;
        }

        public async Task<Guid> Update(
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
            Guid? publishingHouseID)
        {
            bool bookExist = await _context.Books.AnyAsync(b => b.BookId == bookId);

            if (!bookExist)
            {
                throw new Exception("This book doesn't exist!");
            }

            await _context.Books
                .Where(b => b.BookId == bookId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.AuthorName, b => authorName)
                    .SetProperty(b => b.PublicationYear, b => publicationYear)
                    .SetProperty(b => b.Genre, b => genre)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price)
                    .SetProperty(b => b.CountPages, b => countPages)
                    .SetProperty(b => b.PublishingHouseName, b => publishingHouseName)
                    .SetProperty(b => b.Series, b => series)
                    .SetProperty(b => b.ISBN, b => isbn)
                    .SetProperty(b => b.Quantity, b => quantity)
                    .SetProperty(b => b.AuthorId, authorId)
                    .SetProperty(b => b.PublishingHouseId, publishingHouseID));

            return bookId;
        }

        public async Task<Guid> Delete(Guid bookId)
        {
            bool bookExist = await _context.Books.AnyAsync(b => b.BookId == bookId);

            if (!bookExist)
            {
                throw new Exception("This book doesn't exist!");
            }

            await _context.Books
                .Where(b => b.BookId == bookId)
                .ExecuteDeleteAsync();

            return bookId;
        }
    }
}