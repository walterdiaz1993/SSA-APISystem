using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.UserAppServices;
using Services.NetCore.Crosscutting.Dtos.UserDto;

namespace Services.NetCore.WebApi.Controllers.User
{
    [ApiController]
    [Route("api/v2/security/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("authentica-user")]
        public async Task<IActionResult> AuthenticaUser(AuthenticateUserRequest request)
        {
            var response = await _userAppService.AuthenticaUserAsync(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("create-or-update-user")]
        public async Task<IActionResult> CreateOrUpdateUser(UserRequest request)
        {
            var response = await _userAppService.CreateOrUpdateUserAsync(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("get-users")]
        public async Task<IActionResult> GetUsers([FromQuery] string searchValue = null)
        {
            var response = await _userAppService.GetUsersAsync(searchValue);

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove-user")]
        public async Task<IActionResult> RemoveUser(DeleteUserRequest deleteUserRequest)
        {
            var response = await _userAppService.RemoveUserAsync(deleteUserRequest);

            return Ok(response);
        }

    }
}
