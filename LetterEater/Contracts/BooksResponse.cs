namespace LetterEater.Contracts
{
    public record BooksResponse (
        Guid BookId, 
        string Title, 
        string Genre, 
        string Description, 
        decimal Price, 
        int CountPages, 
        string Series, 
        string ISBN, 
        int Quantity, 
        Guid AuthorId, 
        Guid PublishingHouseId);
}