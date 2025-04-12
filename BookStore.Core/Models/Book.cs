using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 200;
        public const int MAX_DESCRIPTIONLENGTH = 500;

        private Book(Guid bookId, string author, string title, string genre, string description, decimal price, int countPages, string  publishingHouse, string series, string isbn, int quantity)
        {
            BookId = bookId;
            Author = author;
            Title = title;
            Genre = genre;
            Description = description;
            Price = price;
            CountPages = countPages;
            PublishingHouse = publishingHouse;
            Series = series;
            ISBN = isbn;
            Quantity = quantity;
        }

        public Guid BookId { get; }

        public string Author { get; }

        public string Title { get; }

        public string Genre { get; }

        public string Description { get; }

        public decimal Price { get; }

        public int CountPages { get; }

        public string PublishingHouse { get; }

        public string Series { get; }

        public string ISBN { get; }

        public int Quantity { get; }
    }
}