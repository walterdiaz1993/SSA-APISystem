using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.UserDto;

namespace Services.NetCore.Application.Services.UserAppServices
{
    public interface IUserAppService
    {
        Task<UserResponse> AuthenticaUserAsync(AuthenticateUserRequest request);
        Task<Response> CreateOrUpdateUserAsync(UserRequest request);
        Task<Response> RemoveUserAsync(DeleteUserRequest deleteUserRequest);
        Task<UserResponse> GetUsersAsync(string searchValue = null);
        Task<UserResponse> GetUserAsync(string userName = null);
        Task<UserResponse> UpdatePassword(AuthenticateUserRequest request);
    }
}
