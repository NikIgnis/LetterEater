using LetterEater.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Entities
{
    public class AuthorEntity
    {
        [Key]
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        [ForeignKey(nameof(BookEntity))]
        public List<BookEntity> Books { get; set; }
    }
}