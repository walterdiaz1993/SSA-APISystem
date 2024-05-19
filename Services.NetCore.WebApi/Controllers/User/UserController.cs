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
        public async Task<IActionResult> AuthenticaUser(UserRequest request)
        {
            var response = await _userAppService.AuthenticaUser(request);

            return Ok(response);
        }
    }
}
