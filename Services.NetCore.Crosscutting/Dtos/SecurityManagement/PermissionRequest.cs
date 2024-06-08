using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.SecurityManagement
{
    public class PermissionRequest : RequestBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsGranted { get; set; }
        public int RoleId { get; set; }
    }
}
