using Microsoft.AspNetCore.Mvc;
using UserService.API.Contracts;
using UserService.Core.Abstractions;
using UserService.Core.Models;

namespace UserService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminsService _adminsService;
        public AdminsController(IAdminsService adminsService)
        {
            _adminsService = adminsService;
        }
       
        [HttpGet]
        public async Task<ActionResult<List<AdminsResponse>>> GetAdmins()
        {
            var admins = await _adminsService.GetAllAdmins();

            var response = admins.Select(a => new AdminsResponse(
                a.AdminId,
                a.Name,
                a.Surename,
                a.ContactNumber,
                a.Email,
                a.Password));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNewAdmin([FromBody] AdminsRequest adminsrequest)
        {
            var admin = Admin.Create(
                Guid.NewGuid(),
                adminsrequest.Name,
                adminsrequest.Surename,
                adminsrequest.ContactNumber,
                adminsrequest.Email,
                adminsrequest.Password);

            var userId = await _adminsService.CreateAdmin(admin);

            return Ok(userId);
        }

        [HttpPut("{adminId:guid}")]
        public async Task<ActionResult<Guid>> UpdateAdmin(Guid adminId, [FromBody] AdminsRequest adminsRequest)
        {
            var admin = await _adminsService.UpdateAdmin(
                adminId,
                adminsRequest.Name,
                adminsRequest.Surename,
                adminsRequest.ContactNumber,
                adminsRequest.Email,
                adminsRequest.Password);

            return Ok(admin);
        }

        [HttpDelete("{adminId:guid}")]
        public async Task<ActionResult<Guid>> DeleteAdmin(Guid adminId)
        {
            return Ok(await _adminsService.DeleteAdmin(adminId));
        }
    }
}