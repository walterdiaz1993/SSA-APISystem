using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.SecurityManagement
{
    public class UserRoleRequest : RequestBase
    {
        public List<RolesPermissionsDto> RolesPermissions { get; set; }
        public List<int> UsersIds { get; set; }
    }

    public class RolesPermissionsDto
    {
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
