using LetterEater.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Core.Models
{
    public class Author
    {
        public Author(Guid authorId, string name, string surename, List<Book> books)
        {
            AuthorId = authorId;
            Name = name;
            Surename = surename;
            Books = new List<Book>(books);
        }

        public Guid AuthorId { get; }

        public string Name { get; }

        public string Surename { get; }

        public List<Book> Books { get; }

        public static Author Create(Guid authorId, string name, string surename, List<Book> books)
        {
            return new Author(authorId, name, surename, new List<Book>(books));
        }
    }
}
