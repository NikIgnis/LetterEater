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
                throw new Exception("This book is already available");
            }

            var bookEntity = new BookEntity()
            {
                BookId = book.BookId,
                Title = book.Title,
                Genre = book.Genre,
                Description = book.Description,
                Price = book.Price,
                CountPages = book.CountPages,
                Series = book.Series,
                ISBN = book.ISBN,
                Quantity = book.Quantity,
                AuthorId = book.AuthorId,
                PublishingHouseId = book.PublishingHouseId
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            var newAuthor = await _context.Authors
                .Include(a => a.AuthorId)
                .FirstOrDefaultAsync(a => a.AuthorId == book.AuthorId);

            var newPublishingHouse = await _context.PublishingHouses
                .Include(a => a.PublishingHouseId)
                .FirstOrDefaultAsync(a => a.PublishingHouseId == book.PublishingHouseId);

            newAuthor.Books.Add(bookEntity);
            newPublishingHouse.Books.Add(bookEntity);

            return bookEntity.BookId;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities
                .Select(b => Book.Create(b.BookId, b.Title, b.Genre, b.Description, b.Price, b.CountPages, b.Series, b.ISBN, b.Quantity, b.AuthorId, b.PublishingHouseId))
                .ToList();

            return books;
        }

        public async Task<Guid> Update(Guid bookId, string title, string genre, string description, decimal price, int countPages, string series, string isbn, int quantity, Guid authorId, Guid publishingHouseID)
        {
            var book = await _context.Books
                .Include(b => b.AuthorId)
                .Include(b => b.PublishingHouseId)
                .FirstOrDefaultAsync();

            var oldAuthorId = book.AuthorId;
            var oldPublishingHouseId = book.PublishingHouseId;

            await _context.Books
                .Where(b => b.BookId == bookId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Genre, b => genre)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Price, b => price)
                    .SetProperty(b => b.CountPages, b => countPages)
                    .SetProperty(b => b.Series, b => series)
                    .SetProperty(b => b.ISBN, b => isbn)
                    .SetProperty(b => b.Quantity, b => quantity)
                    .SetProperty(b => b.AuthorId, authorId)
                    .SetProperty(b => b.PublishingHouseId, publishingHouseID));

            if(oldAuthorId != authorId)
            {
                var oldAuthor = await _context.Authors
                    .Include(a => a.Books)
                    .FirstOrDefaultAsync(a => a.AuthorId == oldAuthorId);

                var newAuthor = await _context.Authors
                    .Include(a => a.Books)
                    .FirstOrDefaultAsync(a => a.AuthorId == authorId);

                if (oldAuthor != null && oldAuthor.Books.Contains(book)) oldAuthor.Books.Remove(book);
                if (newAuthor != null && newAuthor.Books.Contains(book)) newAuthor.Books.Add(book);
            }

            if(oldPublishingHouseId != publishingHouseID)
            {
                var oldPublishingHouse = await _context.PublishingHouses
                    .Include(a => a.Books)
                    .FirstOrDefaultAsync(a => a.PublishingHouseId == oldPublishingHouseId);

                var newPublishingHouse = await _context.PublishingHouses
                    .Include (a => a.Books)
                    .FirstOrDefaultAsync(a => a.PublishingHouseId == publishingHouseID);

                if(oldPublishingHouse != null && oldPublishingHouse.Books.Contains(book)) oldPublishingHouse.Books.Remove(book);
                if(newPublishingHouse != null && newPublishingHouse.Books.Contains(book)) newPublishingHouse.Books.Add(book);
            }

            return bookId;
        }

        public async Task<Guid> Delete(Guid bookId)
        {
            var author = await _context.Authors
                .Include(a => a.AuthorId)
                .FirstOrDefaultAsync();

            var publishingHouse = await _context.PublishingHouses
                .Include(b => b.PublishingHouseId)
                .FirstOrDefaultAsync();

            var booksToRemove = author.Books.Where(b => b.BookId == bookId).ToList();

            foreach (var book in booksToRemove) author.Books.Remove(book);
            foreach (var book in booksToRemove) publishingHouse.Books.Remove(book);

            await _context.Books
                .Where(b => b.BookId == bookId)
                .ExecuteDeleteAsync();

            return bookId;
        }
    }
}