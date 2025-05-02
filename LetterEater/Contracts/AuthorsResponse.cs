using LetterEater.Core.Models;
namespace LetterEater.Contracts
{
    public record AuthorsResponse(
    Guid AuthorId,
    string Name,
    string Surename,
    List<Guid> BooksId);
}