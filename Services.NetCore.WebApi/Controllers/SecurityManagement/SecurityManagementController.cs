using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.SecurityManagementAppServices;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.SecurityManagement;

namespace Services.NetCore.WebApi.Controllers.SecurityManagement
{
    [ApiController]
    [Route("api/v2/security-managements")]
    public class SecurityManagementController : ControllerBase
    {
        private readonly ISecurityManagementAppService _securityManagementAppService;

        public SecurityManagementController(ISecurityManagementAppService securityManagerAppService)
        {
            _securityManagementAppService = securityManagerAppService;
        }

        [HttpGet]
        [Route("accesses-by-username")]
        public async Task<IActionResult> GetAccessesByUserName([FromQuery] string userName)
        {
            var response = await _securityManagementAppService.GetAccessesByUserName(userName);

            return Ok(response);
        }

        [HttpGet]
        [Route("get-all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _securityManagementAppService.GetAllRoles();

            return Ok(response);
        }

        [HttpPost]
        [Route("create-or-update-permission")]
        public async Task<IActionResult> CreateOrUpdatePermission(PermissionRequest request)
        {
            var response = await _securityManagementAppService.CreateOrUpdatePermission(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("create-or-update-role")]
        public async Task<IActionResult> CreateOrUpdateRole(RoleRequest request)
        {
            var response = await _securityManagementAppService.CreateOrUpdateRole(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("provide-access")]
        public async Task<IActionResult> ProvideAccess(UserRoleRequest request)
        {
            var response = await _securityManagementAppService.ProvideAccesess(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove-permission")]
        public async Task<IActionResult> RemovePermission(PermissionRequest request)
        {
            var response = await _securityManagementAppService.DeletePermission(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove-role")]
        public async Task<IActionResult> RemoveRole(RoleRequest request)
        {
            var response = await _securityManagementAppService.DeleteRole(request);

            return Ok(response);
        }


        [HttpDelete]
        [Route("remove-access-role-to-user")]
        public async Task<IActionResult> RemoveAccessRoleToUser(int id, int userId, RequestBase request)
        {
            var response = await _securityManagementAppService.RemoveAccessRoleToUser(id, userId, request.RequestUserInfo);

            return Ok(response);
        }


        [HttpDelete]
        [Route("remove-access-permission-to-user")]
        public async Task<IActionResult> RemoveAccessPermissionToUser(int id, int userId, RequestBase request)
        {
            var response = await _securityManagementAppService.RemoveAccessPermissionToUser(id, userId, request.RequestUserInfo);

            return Ok(response);
        }
    }
}
