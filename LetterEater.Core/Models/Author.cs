using LetterEater.Core.Models;

public class Author
{
    public Author(Guid authorId, string name, string surename, List<Book> books)
    {
        AuthorId = authorId;
        Name = name;
        Surename = surename;
        Books = books != null ? new List<Book>(books) : new List<Book>();
    }

    public Guid AuthorId { get; }

    public string Name { get; }

    public string Surename { get; }

    public List<Book> Books { get; }

    public static Author Create(Guid authorId, string name, string surename, List<Book> books)
    {
        return new Author(authorId, name, surename, books);
    }
}