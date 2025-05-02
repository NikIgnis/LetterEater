using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
namespace LetterEater.Contracts
{
    public record class OrdersResponse(
    Guid OrderId,
    Guid UserId,
    DateTime OrderDate,
    List<Guid> OrderItemsId);
}