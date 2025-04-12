using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess
{
    public class LetterEaterDbContext : DbContext
    {
        public LetterEaterDbContext(DbContextOptions<LetterEaterDbContext> options) : base(options)
        {

        }

        DbSet<BookEntity> Books { get; set; }
    }
}
