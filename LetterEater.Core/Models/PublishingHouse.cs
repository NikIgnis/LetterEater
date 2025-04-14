using LetterEater.Core.Models;

public class PublishingHouse
{
    public PublishingHouse(Guid publishingHouseId, string name, List<Book> books)
    {
        PublishingHouseId = publishingHouseId;
        Name = name;
        Books = books != null ? new List<Book>(books) : new List<Book>();
    }

    public Guid PublishingHouseId { get; }

    public string Name { get; }

    public List<Book> Books { get; }

    public static PublishingHouse Create(Guid publishingHouseId, string name, List<Book> books)
    {
        return new PublishingHouse(publishingHouseId, name, books);
    }
}