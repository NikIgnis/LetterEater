using LetterEater.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class PublishingHouse
    {
        public PublishingHouse(Guid publishingHouseId, string name, List<Book> books)
        {
            PublishingHouseId = publishingHouseId;
            Name = name;
            Books = books;
        }

        public Guid PublishingHouseId { get; }

        public string Name { get; }

        public List<Book> Books { get; }
    }
}
