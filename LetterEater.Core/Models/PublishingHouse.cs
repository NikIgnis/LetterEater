using LetterEater.Core.Models;

public class PublishingHouse
{
    public PublishingHouse(Guid publishingHouseId, string name, List<Guid> booksId)
    {
        PublishingHouseId = publishingHouseId;
        Name = name;
        BooksId = booksId != null ? new List<Guid>(booksId) : new List<Guid>();
    }

    public Guid PublishingHouseId { get; }

    public string Name { get; }

    public List<Guid> BooksId { get; }

    public static PublishingHouse Create(Guid publishingHouseId, string name, List<Guid> booksId)
    {
        return new PublishingHouse(publishingHouseId, name, booksId);
    }
}