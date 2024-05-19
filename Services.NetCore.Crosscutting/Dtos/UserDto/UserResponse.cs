using Services.NetCore.Crosscutting.Dtos.Produce;

namespace Services.NetCore.Crosscutting.Dtos.UserDto
{
    public class UserResponse : ResponseBase
    {
        public UserDto User { get; set; }
    }

    public class UserDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
