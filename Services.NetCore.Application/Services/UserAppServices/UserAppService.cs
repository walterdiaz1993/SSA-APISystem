using AutoMapper;
using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.UserDto;
using Services.NetCore.Crosscutting.Helpers;
using Services.NetCore.Domain.Aggregates.UserAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.UserAppServices
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IMapper _mapper;
        public UserAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<UserResponse> AuthenticaUserAsync(AuthenticateUserRequest request)
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

        public async Task<Response> CreateOrUpdateUserAsync(UserRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.User, nameof(request.User));

            var existingUser = await _repository.GetSingleAsync<User>(u => u.UserName == request.User.UserName);
            TransactionInfo transactionInfo;

            if (existingUser != null)
            {
                existingUser.Password = AESEncryptor.Encrypt(request.User.Password);
                existingUser.Device = request.User.Device;
                existingUser.DeviceId = request.User.DeviceId;
                existingUser.Residential = request.User.Residential;
                existingUser.Gender = request.User.Gender;

                transactionInfo = TransactionInfoFactory.CrearTransactionInfo(request.RequestUserInfo, Transactions.UpdateUser);
            }
            else
            {
                var newUser = _mapper.Map<User>(request.User);
                newUser.Password = AESEncryptor.Encrypt(newUser.Password);

                transactionInfo = TransactionInfoFactory.CrearTransactionInfo(request.RequestUserInfo, Transactions.CreateUser);
                await _repository.AddAsync(newUser);
            }

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<UserResponse> GetUsersAsync(string searchValue = null)
        {
            IEnumerable<User> users;

            if (!string.IsNullOrEmpty(searchValue))
            {
                users = await _repository.GetFilteredAsync<User>(u => u.UserName.Contains(searchValue) ||
                                                               u.Device.Contains(searchValue) ||
                                                               u.Residential.Contains(searchValue));
            }
            else
            {
                users = await _repository.GetFilteredAsync<User>(x => x.IsActive);
            }

            var userDtos = _mapper.Map<List<UserDto>>(users);

            return new UserResponse { Success = true, Users = userDtos };
        }

        public async Task<Response> RemoveUserAsync(DeleteUserRequest deleteUserRequest)
        {
            ThrowIf.Argument.IsNull(deleteUserRequest, nameof(deleteUserRequest));
            ThrowIf.Argument.IsZeroOrNegative(deleteUserRequest.UserId, nameof(deleteUserRequest.UserId));

            var user = await _repository.GetSingleAsync<User>(x => x.Id == deleteUserRequest.UserId);
            if (user == null) return new Response { Success = false, Message = "User not found" };

            await _repository.RemoveAsync(user);

            TransactionInfo transactionInfo = TransactionInfoFactory.CrearTransactionInfo(deleteUserRequest.RequestUserInfo, Transactions.DeleteUser);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }
    }
}
