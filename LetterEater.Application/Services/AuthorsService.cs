using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using LetterEater.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Application.Services
{
    public class AuthorsService : IAuthorsService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Guid> CreateAuthor(Author author)
        {
            return await _authorRepository.Create(author);
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _authorRepository.Get();
        }

        public async Task<Guid> UpdateAuthor(Guid authorId, string name, string surename, List<Guid> booksId)
        {
            return await _authorRepository.Update(authorId, name, surename, booksId);
        }

        public async Task<Guid> DeleteAuthor(Guid authorId)
        {
            return await _authorRepository.Delete(authorId);
        }
    }
}