using LetterEater.Core.Models;

namespace LetterEater.Contracts
{
    public record AuthorsRequest(
        Guid AuthorId,
        string Name,
        string Surename,
        List<Book> Books);
}