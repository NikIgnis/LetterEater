namespace UserService.API.Contracts
{
    public record AdminsResponse(
    Guid AdminId,
    string Name,
    string Surename,
    string ContactNumber,
    string Email,
    string Password);
}