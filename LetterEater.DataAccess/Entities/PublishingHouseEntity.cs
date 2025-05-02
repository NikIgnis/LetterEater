using LetterEater.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

public class PublishingHouseEntity
{
    [Key]
    public Guid PublishingHouseId { get; set; }

    public string Name { get; set; }

    public List<Guid>? BooksId { get; set; } = new List<Guid>();

    //Dependencies
    public List<BookEntity>? Books { get; set; }
}