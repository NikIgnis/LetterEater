namespace LetterEater.Contracts
{
    public record class OrderItemsRequest(
    Guid OrderId,
    Guid BookId,
    int Quantity,
    decimal Price);
}