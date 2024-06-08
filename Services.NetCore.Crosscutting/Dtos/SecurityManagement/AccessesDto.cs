namespace Services.NetCore.Crosscutting.Dtos.SecurityManagement
{
    public class AccessesDto
    {
        public int RoleId { get; set; }
        public string RolName { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public List<PermissionDto> Permissions { get; set; }
    }
}
