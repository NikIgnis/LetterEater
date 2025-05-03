using CatalogService.Core.Abstractions;
using CatalogService.Core.Models;
using CatalogService.DataAccess;
using CatalogService.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LetterEater.DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly CatalogDbContext _context;

        public AuthorRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Author author)
        {
            bool authorExist = await _context.Authors.AnyAsync(a => a.AuthorId == author.AuthorId);

            if (authorExist)
            {
                throw new Exception("This author is already available");
            }

            var authorEntity = new AuthorEntity()
            {
                AuthorId = author.AuthorId,
                Name = author.Name,
                Surename = author.Surename,
                BooksId = new List<Guid>(author.BooksId)
            };

            await _context.Authors.AddAsync(authorEntity);
            await _context.SaveChangesAsync();

            return author.AuthorId;
        }

        public async Task<List<Author>> Get()
        {
            var authorEntities = await _context.Authors
                .AsNoTracking()
                .ToListAsync();

            var authors = authorEntities
                .Select(a => Author.Create(
                    a.AuthorId,
                    a.Name,
                    a.Surename,
                    new List<Guid>(a.BooksId)
                ))
                .ToList();

            return authors;
        }

        public async Task<Guid> Update(Guid authorId, string name, string surename, List<Guid> booksId)
        {
            bool authorExists = await _context.Authors
                .AnyAsync(a => a.AuthorId == authorId);

            if (!authorExists)
            {
                throw new Exception("Author doesn't exist!");
            }

            await _context.Authors
                .Where(a => a.AuthorId == authorId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, s => name)
                    .SetProperty(b => b.Surename, s => surename)
                    .SetProperty(b => b.BooksId, s => new List<Guid>(booksId)));

            return authorId;
        }

        public async Task<Guid> Delete(Guid authorId)
        {
            bool authorExist = await _context.Authors.AnyAsync(a => a.AuthorId == authorId);

            if (!authorExist)
            {
                throw new Exception("Author doesn't exist!");
            }

            await _context.Authors
                .Where(b => b.AuthorId == authorId)
                .ExecuteDeleteAsync();

            return authorId;
        }
    }
}