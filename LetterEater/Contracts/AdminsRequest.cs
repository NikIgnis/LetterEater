namespace LetterEater.Contracts
{
    public record AdminsRequest(
    string Name,
    string Surename,
    string ContactNumber,
    string Email,
    string Password);
}