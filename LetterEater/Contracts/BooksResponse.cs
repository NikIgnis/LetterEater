namespace LetterEater.Contracts
{
    public record BooksResponse (
        Guid bookId, 
        string title, 
        string genre, 
        string description, 
        decimal price, 
        int countPages, 
        string series, 
        string isbn, 
        int quantity, 
        Guid authorId, 
        Guid publishingHouseId);
}