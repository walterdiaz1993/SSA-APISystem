using Services.NetCore.Crosscutting.Dtos.UserDto;

namespace Services.NetCore.Application.Services.UserAppServices
{
    public interface IUserAppService
    {
        Task<UserResponse> AuthenticaUser(UserRequest request);
    }
}
