namespace CatalogService.API.Contracts
{
    public record AuthorsResponse(
    Guid AuthorId,
    string Name,
    string Surename,
    List<Guid> BooksId);
}