using LetterEater.Core.Models;
namespace LetterEater.Contracts
{
    public record class OrdersRequest(
    Guid UserId,
    DateTime OrderDate,
    List<Guid> OrderItemsId);
}