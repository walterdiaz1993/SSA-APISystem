using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.SecurityManagement
{
    public class RolesResponse : ResponseBase
    {
        public List<RoleDto> Roles { get; set; }
    }

    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PermissionDto> Permissions { get; set; }
    }
}
