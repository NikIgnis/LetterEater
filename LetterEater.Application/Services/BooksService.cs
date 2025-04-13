using LetterEater.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Application.Services
{
    public class BooksService
    {
        private readonly IBookRepository _boolRepository;

        public BooksService(IBookRepository boolRepository)
        {
            _boolRepository = boolRepository;
        }


    }
}
