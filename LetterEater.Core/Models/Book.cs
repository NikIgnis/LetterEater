using LetterEater.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LetterEater.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 200;
        public const int MAX_DESCRIPTIONLENGTH = 500;

        private Book(Guid bookId, string title, string genre, string description, decimal price, int countPages, string series, string isbn, int quantity, Guid authorId, Guid publishingHouseId)
        {
            BookId = bookId;
            Title = title;
            Genre = genre;
            Description = description;
            Price = price;
            CountPages = countPages;
            Series = series;
            ISBN = isbn;
            Quantity = quantity;
            AuthorId = AuthorId;
            PublishingHouseId = publishingHouseId;
        }

        public Guid BookId { get; }

        public string Title { get; }

        public string AuthorName => Author?.Name[0] + ". " + Author?.Surename;

        public string Genre { get; }

        public string Description { get; }

        public decimal Price { get; }

        public int CountPages { get; }

        public string PublishingHouseName => PublishingHouse?.Name;

        public string Series { get; }

        public string ISBN { get; }

        public int Quantity { get; }

        public Guid AuthorId { get; }

        public Guid PublishingHouseId { get; }

        public Author Author { get; }

        public PublishingHouse PublishingHouse { get; }

        public static Book Create(Guid bookId, string title, string genre, string description, decimal price, int countPages, string series, string isbn, int quantity, Guid authorId, Guid publishingHouseId)
        {
            return new Book(bookId, title, genre, description, price, countPages, series, isbn, quantity, authorId, publishingHouseId);
        }
    }
}