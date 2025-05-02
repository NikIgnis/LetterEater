using LetterEater.Core.Models;

public class Author
{
    public Author(Guid authorId, string name, string surename, List<Guid> booksId)
    {
        AuthorId = authorId;
        Name = name;
        Surename = surename;
        BooksId = booksId != null ? new List<Guid>(booksId) : new List<Guid>();
    }

    public Guid AuthorId { get; }

    public string Name { get; }

    public string Surename { get; }

    public List<Guid> BooksId { get; }

    public static Author Create(Guid authorId, string name, string surename, List<Guid> books)
    {
        return new Author(authorId, name, surename, books);
    }
}