using LetterEater.Core.Models;

namespace LetterEater.Contracts
{
    public record PublishingHousesResponse(
        Guid PublishingHousesId,
        string Name,
        List<Guid> BooksId);
}