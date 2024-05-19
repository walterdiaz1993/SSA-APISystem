using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.UserDto;
using Services.NetCore.Crosscutting.Helpers;
using Services.NetCore.Domain.Aggregates.UserAgg;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.UserAppServices
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        public UserAppService(IGenericRepository<IGenericDataContext> repository) : base(repository)
        {
        }

        public async Task<UserResponse> AuthenticaUser(UserRequest request)
        {
            string username = request.UserName;
            string password = AESEncryptor.Encrypt(request.Password);

            var user = await _repository.GetSingleAsync<User>(x => x.UserName == username && x.Password == password);

            if (user == null)
            {
                return new UserResponse { ValidationErrorMessage = CommonsDictionary.InvalidUserNameOrPassword };
            }

            return new UserResponse
            {
                Success = true,
                User = new UserDto
                {
                    UserName = user.UserName,
                }
            };
        }
    }
}
