using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.SecurityManagement;

namespace Services.NetCore.Application.Services.SecurityManagementAppServices
{
    public interface ISecurityManagementAppService
    {
        Task<List<AccessesDto>> GetAccessesByUserName(string userName);
        Task<RolesResponse> GetAllRoles();
        Task<ResponseBase> CreateOrUpdatePermission(PermissionRequest request);
        Task<ResponseBase> CreateOrUpdateRole(RoleRequest request);
        Task<ResponseBase> DeletePermission(int id, UserInfoDto requestUserInfo);
        Task<ResponseBase> DeleteRole(int id, UserInfoDto requestUserInfo);
        Task<ResponseBase> ProvideAccesess(UserRoleRequest request);
        Task<ResponseBase> RemoveAccessRoleToUser(int id, int UserId, UserInfoDto requestUserInfo);
        Task<ResponseBase> RemoveAccessPermissionToUser(int id, int userId, UserInfoDto requestUserInfo);
    }
}
