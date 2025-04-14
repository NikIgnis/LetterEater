using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Repositories
{
    public class PublishingHousesRepository : IPublishingHousesRepository
    {
        private readonly LetterEaterDbContext _context;

        public PublishingHousesRepository(LetterEaterDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(PublishingHouse publishingHouse)
        {
            bool publishingHouseExist = await _context.PublishingHouses.AnyAsync(b => b.PublishingHouseId == publishingHouse.PublishingHouseId);

            if (publishingHouseExist)
            {
                throw new Exception("Publishing house is available!");
            }

            var publishingHouseEntity = new PublishingHouseEntity()
            {
                PublishingHouseId = publishingHouse.PublishingHouseId,
                Name = publishingHouse.Name,
                Books = publishingHouse.Books.Select(book => new BookEntity
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
                    PublishingHouseId = publishingHouse.PublishingHouseId
                }).ToList()
            };

            await _context.PublishingHouses.AddAsync(publishingHouseEntity);
            await _context.SaveChangesAsync();

            return publishingHouse.PublishingHouseId;
        }

        public async Task<List<PublishingHouse>> Get()
        {
            bool publishingHouseExist = await _context.PublishingHouses.AnyAsync();

            if (!publishingHouseExist)
            {
                throw new Exception("Publishing houses don't available");
            }

            var publishingHouseEntity = await _context.PublishingHouses
                .AsNoTracking()
                .ToListAsync();

            var publishingHouse = publishingHouseEntity
                .Select(a => PublishingHouse.Create(
                a.PublishingHouseId,
                a.Name,
                a.Books.Select(bookEntity => Book.Create(
                    bookEntity.BookId,
                    bookEntity.Title,
                    bookEntity.Genre,
                    bookEntity.Description,
                    bookEntity.Price,
                    bookEntity.CountPages,
                    bookEntity.Series,
                    bookEntity.ISBN,
                    bookEntity.Quantity,
                    bookEntity.AuthorId,
                    a.PublishingHouseId
                    )).ToList()
                ))
                .ToList();

            return publishingHouse;
        }

        public async Task<Guid> Update(Guid publishingHouseId, string name, List<Book> books)
        {
            bool publishingHouseExists = await _context.PublishingHouses
                .AnyAsync(b => b.PublishingHouseId == publishingHouseId);

            if (!publishingHouseExists)
            {
                throw new Exception("Publishing house doesn't exist!");
            }

            await _context.PublishingHouses
                .Where(a => a.PublishingHouseId == publishingHouseId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, name));

            var publishingHouse = await _context.PublishingHouses
                .Include(ph => ph.Books)
                .FirstOrDefaultAsync(ph => ph.PublishingHouseId == publishingHouseId);

            if (publishingHouse == null)
            {
                throw new Exception("Publishing house not found.");
            }

            publishingHouse.Books.Clear();

            foreach (var book in books)
            {
                var bookEntity = new BookEntity
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
                    PublishingHouseId = publishingHouseId
                };

                publishingHouse.Books.Add(bookEntity);
            }

            await _context.SaveChangesAsync();

            return publishingHouseId;
        }

        public async Task<Guid> Delete(Guid publishingHouseId)
        {
            bool publishingHouseExist = await _context.PublishingHouses.AnyAsync(b => b.PublishingHouseId == publishingHouseId);

            if (!publishingHouseExist)
            {
                throw new Exception("Publishing house doesn't exist!");
            }

            await _context.PublishingHouses
                .Where(b => b.PublishingHouseId == publishingHouseId)
                .ExecuteDeleteAsync();

            return publishingHouseId;
        }
    }
}