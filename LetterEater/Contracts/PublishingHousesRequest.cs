using LetterEater.Core.Models;

namespace LetterEater.Contracts
{
    public record PublishingHousesRequest(
        Guid PublishingHouseId,
        string Name,
        List<Book> Books);
}