using LetterEater.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

public class AuthorEntity
{
    [Key]
    public Guid AuthorId { get; set; }

    public string Name { get; set; }

    public string Surename { get; set; }

    public List<BookEntity> Books { get; set; } = new();
}