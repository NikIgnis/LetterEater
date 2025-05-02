namespace OrderService.API.Contracts
{
    public record class CartItemsResponse(
    Guid CartItemId,
    Guid UserId,
    Guid BookId,
    int Quantity,
    decimal Price);
}