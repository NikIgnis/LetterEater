namespace OrderService.API.Contracts
{
    public record class OrdersRequest(
    Guid UserId,
    DateTime OrderDate,
    List<Guid> OrderItemsId);
}