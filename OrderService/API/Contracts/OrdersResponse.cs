namespace OrderService.API.Contracts
{
    public record class OrdersResponse(
    Guid OrderId,
    Guid UserId,
    DateTime OrderDate,
    List<Guid> OrderItemsId);
}