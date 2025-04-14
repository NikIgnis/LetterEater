using LetterEater.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

public class PublishingHouseEntity
{
    [Key]
    public Guid PublishingHouseId { get; set; }

    public string Name { get; set; }

    public List<BookEntity> Books { get; set; } = new();
}