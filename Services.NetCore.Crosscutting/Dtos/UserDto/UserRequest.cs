using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.UserDto
{
    public class UserRequest : RequestBase
    {
        public UserDto User { get; set; }
    }

    public class AuthenticateUserRequest : RequestBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class DeleteUserRequest : RequestBase
    {
        public int UserId { get; set; }
    }
}
