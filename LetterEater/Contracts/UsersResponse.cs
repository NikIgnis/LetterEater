using LetterEater.Core.Models;

namespace LetterEater.Contracts
{
    public record UsersResponse(
        Guid UserId,
        string Name,
        string Surename,
        string Login,
        string ContactNumber,
        string Email,
        string Password,
        List<Guid> OrdersId);
}