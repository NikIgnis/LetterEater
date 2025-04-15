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

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public int PublicationYear { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CountPages { get; set; }

        public string PublishingHouseName { get; set; }

        public string? Series { get; set; }

        public string ISBN { get; set; }

        public int Quantity { get; set; }

        public Guid? AuthorId { get; set; }

        public Guid? PublishingHouseId { get; set; }

        public AuthorEntity? Author { get; set; }

        public PublishingHouseEntity? PublishingHouse { get; set; }
    }
}