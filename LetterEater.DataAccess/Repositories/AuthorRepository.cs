using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Repositories
{
    public class AuthorRepository
    {
        private readonly LetterEaterDbContext _context;

        public AuthorRepository(LetterEaterDbContext context)
        {
            _context = context;
        }
    }
}
