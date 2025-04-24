using LetterEater.Application.Services;
using LetterEater.Contracts;
using LetterEater.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetterEater.Controllers
{
    [ApiController]
    [Route("api/Users/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(u => new UsersResponse(
                u.UserId,
                u.Name,
                u.Surename,
                u.Login,
                u.ContactNumber,
                u.Email,
                u.Password,
                u.Orders));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewUser([FromBody] UsersRequest usersRequest)
        {
            var user = LetterEater.Core.Models.User.Create(
                Guid.NewGuid(),
                usersRequest.Name,
                usersRequest.Surename,
                usersRequest.Login,
                usersRequest.ContactNumber,
                usersRequest.Email,
                usersRequest.Password,
                usersRequest.Orders);

            var userId = await _usersService.CreateUser(user);
            
            return Ok(userId);
        }

        [HttpPut("{userId:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid userId, [FromBody] UsersRequest usersRequest)
        {
            var user = await _usersService.UpdateUser(
                userId,
                usersRequest.Name,
                usersRequest.Surename,
                usersRequest.Login,
                usersRequest.ContactNumber,
                usersRequest.Email,
                usersRequest.Password,
                usersRequest.Orders);

            return Ok(user);
        }

        [HttpDelete("{userId:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid userId)
        {
            return Ok(await _usersService.DeleteUser(userId));
        }
    }
}