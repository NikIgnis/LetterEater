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
    public class PublishingHouseEntity
    {
        [Key]
        public Guid PublishingHouseId { get; set; }

        public string Name { get; }

        [ForeignKey(nameof(BookEntity))]
        public List<Book> Books { get; }
    }
}
