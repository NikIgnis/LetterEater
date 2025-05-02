namespace CatalogService.API.Contracts
{
    public record AuthorsRequest(
        Guid AuthorId,
        string Name,
        string Surename,
        List<Guid> BooksId);
}