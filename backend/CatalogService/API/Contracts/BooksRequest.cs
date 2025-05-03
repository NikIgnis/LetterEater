namespace CatalogService.API.Contracts
{
    public record BooksRequest(
        string Title,
        string AuthorName,
        int PublicationYear,
        string Genre,
        string Description,
        decimal Price,
        int CountPages,
        string PublishingHouseName,
        string? Series,
        string ISBN,
        int Quantity,
        Guid? AuthorId,
        Guid? PublishingHouseId);
}