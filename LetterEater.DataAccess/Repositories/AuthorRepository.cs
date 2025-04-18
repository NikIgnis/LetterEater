﻿using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LetterEaterDbContext _context;

        public AuthorRepository(LetterEaterDbContext context)
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
                Books = author.Books.Select(book => new BookEntity
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
                    AuthorId = author.AuthorId,
                    PublishingHouseId = book.PublishingHouseId
                }).ToList()
            };

            await _context.Authors.AddAsync(authorEntity);
            await _context.SaveChangesAsync();

            return author.AuthorId;
        }

        public async Task<List<Author>> Get()
        {
            bool anyAuthors = await _context.Authors.AnyAsync();

            if (!anyAuthors)
            {
                throw new Exception("Authors doen't available!");
            }

            var authorEntities = await _context.Authors
                .AsNoTracking()
                .ToListAsync();

            var authors = authorEntities
                .Select(a => Author.Create(
                    a.AuthorId,
                    a.Name,
                    a.Surename,
                    a.Books.Select(bookEntity => Book.Create(
                        bookEntity.BookId,
                        bookEntity.Title,
                        bookEntity.AuthorName,
                        bookEntity.PublicationYear,
                        bookEntity.Genre,
                        bookEntity.Description,
                        bookEntity.Price,
                        bookEntity.CountPages,
                        bookEntity.PublishingHouseName,
                        bookEntity.Series,
                        bookEntity.ISBN,
                        bookEntity.Quantity,
                        a.AuthorId,
                        bookEntity.PublishingHouseId
                    )).ToList()
                ))
                .ToList();

            return authors;
        }

        public async Task<Guid> Update(Guid authorId, string name, string surename, List<Book> books)
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
                    .SetProperty(b => b.Name, name)
                    .SetProperty(b => b.Surename, surename));

            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.AuthorId == authorId);

            if (author == null)
            {
                throw new Exception("Author not found.");
            }

            author.Books.Clear();

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
                    AuthorId = authorId,
                    PublishingHouseId = book.PublishingHouseId
                };

                author.Books.Add(bookEntity);
            }

            await _context.SaveChangesAsync();

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