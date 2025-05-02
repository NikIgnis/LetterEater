using System.ComponentModel.DataAnnotations;

namespace CatalogService.DataAccess.Entities
{
    public class AuthorEntity
    {
        [Key]
        public Guid AuthorId { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public List<Guid>? BooksId { get; set; } = new List<Guid>();


        //Dependencies
        public List<BookEntity>? Books { get; set; }
    }
}