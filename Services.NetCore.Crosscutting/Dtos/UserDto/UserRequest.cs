using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.UserDto
{
    public class UserRequest : RequestBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
