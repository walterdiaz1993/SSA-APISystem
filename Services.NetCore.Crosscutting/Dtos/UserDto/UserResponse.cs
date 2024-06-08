using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.SecurityManagement;

namespace Services.NetCore.Crosscutting.Dtos.UserDto
{
    public class UserResponse : ResponseBase
    {
        public UserDto User { get; set; }
        public List<UserDto> Users { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }
        public string DeviceId { get; set; }
        public string Residential { get; set; }
        public string Gender { get; set; }

        public List<AccessesDto> Accesses { get; set; }
    }
}
