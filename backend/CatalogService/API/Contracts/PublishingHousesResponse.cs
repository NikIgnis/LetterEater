namespace CatalogService.API.Contracts
{
    public record PublishingHousesResponse(
        Guid PublishingHousesId,
        string Name,
        List<Guid> BooksId);
}