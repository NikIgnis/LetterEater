namespace CatalogService.API.Contracts
{
    public record PublishingHousesRequest(
        Guid PublishingHouseId,
        string Name,
        List<Guid> BooksId);
}