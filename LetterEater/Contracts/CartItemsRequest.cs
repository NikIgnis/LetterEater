using LetterEater.Core.Models;
namespace LetterEater.Contracts
{
    public record class CartItemsRequest(
    Guid UserId,
    Guid BookId,
    int Quantity,
    decimal Price);
}
