namespace LetterEater.Contracts
{
    public record BooksRequest(
        string Title,
        string Genre,
        string Description,
        decimal Price,
        int CountPages,
        string Series,
        string ISBN,
        int Quantity,
        Guid AuthorId,
        Guid PublishingHouseId);
}