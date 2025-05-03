namespace OrderService.API.Contracts
{
    public record class OrderItemsResponse(
    Guid OrderItemId,
    Guid OrderId,
    Guid BookId,
    int Quantity,
    decimal Price);
}