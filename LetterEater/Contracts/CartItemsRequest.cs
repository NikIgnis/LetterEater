using LetterEater.Core.Models;
namespace LetterEater.Contracts
{
    public record class CartItemsRequest(
    Guid UserId,
    Guid BookId,
    Book Book,
    int Quantity,
    decimal Price);
}
