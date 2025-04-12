using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Entities
{
    public class BookEntity
    {
        [Key]
        public Guid BookId { get; set;  }

        [ForeignKey(nameof(Author))]
        public string Author { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CountPages { get; set; }

        [ForeignKey(nameof(PublishingHouse))]
        public string PublishingHouse { get; set; }

        public string Series { get; set; }

        public string ISBN { get; set; }

        public int Quantity { get; set; }
    }
}