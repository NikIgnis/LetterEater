﻿namespace UserService.API.Contracts
{
    public record UsersRequest(
        string Name,
        string Surename,
        string Login,
        string ContactNumber,
        string Email,
        string Password,
        List<Guid> OrdersId);
}