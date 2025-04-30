using LetterEater.Core.Models;
namespace LetterEater.Contracts
{
    public record class CartItemsResponse(
    Guid CartItemId,
    Guid UserId,
    Guid BookId,
    Book Book,
    int Quantity,
    decimal Price);
}