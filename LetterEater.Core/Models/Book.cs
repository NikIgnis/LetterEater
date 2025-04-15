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

        private Book(
            Guid bookId,
            string title,
            string authorName,
            int publicationYear,
            string genre,
            string description,
            decimal price,
            int countPages,
            string publishingHouseName,
            string? series,
            string isbn,
            int quantity,
            Guid? authorId,
            Guid? publishingHouseId)
        {
            BookId = bookId;
            Title = title;
            AuthorName = authorName;
            PublicationYear = publicationYear;
            Genre = genre;
            Description = description;
            Price = price;
            CountPages = countPages;
            PublishingHouseName = publishingHouseName;
            Series = series;
            ISBN = isbn;
            Quantity = quantity;
            AuthorId = AuthorId;
            PublishingHouseId = publishingHouseId;
        }

        public Guid BookId { get; }

        public string Title { get; }

        public string AuthorName { get; }

        public int PublicationYear { get; }

        public string Genre { get; }

        public string Description { get; }

        public decimal Price { get; }

        public int CountPages { get; }

        public string PublishingHouseName { get; }

        public string? Series { get; }

        public string ISBN { get; }

        public int Quantity { get; }

        public Guid? AuthorId { get; }

        public Guid? PublishingHouseId { get; }

        public Author? Author { get; }

        public PublishingHouse? PublishingHouse { get; }

        public static Book Create(
            Guid bookId,
            string title,
            string authorName,
            int publicationYear,
            string genre,
            string description,
            decimal price,
            int countPages,
            string publishingHouseName,
            string? series,
            string isbn,
            int quantity,
            Guid? authorId,
            Guid? publishingHouseId)
        {
            return new Book(
                bookId,
                title,
                authorName,
                publicationYear,
                genre,
                description,
                price,
                countPages,
                publishingHouseName,
                series,
                isbn,
                quantity,
                authorId,
                publishingHouseId);
        }
    }
}