using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Services.NetCore.Application.Core;
using Services.NetCore.Application.Services.SecurityManagementAppServices;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.UserDto;
using Services.NetCore.Crosscutting.Helpers;
using Services.NetCore.Domain.Aggregates.AccountAgg;
using Services.NetCore.Domain.Aggregates.ResidenceAgg;
using Services.NetCore.Domain.Aggregates.ResidentialAgg;
using Services.NetCore.Domain.Aggregates.UserAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.UserAppServices
{
    public class UserAppService : BaseAppService, IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly ISecurityManagementAppService _securityManagementAppService;
        public UserAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper, ISecurityManagementAppService securityManagementAppService) : base(repository)
        {
            _mapper = mapper;
            _securityManagementAppService = securityManagementAppService;
        }

        public async Task<UserResponse> AuthenticaUserAsync(AuthenticateUserRequest request)
        {
            string username = request.UserName;
            string password = AESEncryptor.Encrypt(request.Password);

            var user = await _repository.GetSingleAsync<User>(x => x.UserName == username && x.Password == password, new List<string> { "Accounts" });

            if (user == null)
            {
                return new UserResponse { ValidationErrorMessage = CommonsDictionary.InvalidUserNameOrPassword };
            }
            var acceses = await _securityManagementAppService.GetAccessesByUserName(username);
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Accesses = acceses;

            return new UserResponse
            {
                Success = true,
                User = userDto,
            };
        }

        public async Task<Response> CreateOrUpdateUserAsync(UserRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.User, nameof(request.User));

            var existingUser = await _repository.GetSingleAsync<User>(u => u.UserName == request.User.UserName || u.Id == request.User.Id, new List<string> { "Accounts" });
            TransactionInfo transactionInfo;

            if (existingUser != null)
            {
                existingUser.Password = AESEncryptor.Encrypt(request.User.Password);
                existingUser.Device = request.User.Device;
                existingUser.DeviceId = request.User.DeviceId;
                existingUser.Residential = request.User.Residential;
                existingUser.Gender = request.User.Gender;
                existingUser.UserName = request.User.UserName;
                existingUser.Accounts = request.User.Accounts.Select(x => new Account
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    Residence = x.Residence,
                    AccountType = x.AccountType,
                    Residential = x.Residential,
                    Block = x.Block,
                    HouseNumber = x.HouseNumber,
                    ResidentialId = x.ResidentialId,
                    AllowEmergy = x.AllowEmergy,
                    LockCode = x.LockCode,
                    UserId = x.UserId,
                    Email = x.Email,
                }).ToList();

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.UpdateUser);
            }
            else
            {
                var newUser = _mapper.Map<User>(request.User);
                newUser.Password = AESEncryptor.Encrypt(newUser.Password);

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.CreateUser);
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

        public async Task<UserResponse> GetUserAsync(string userName = null)
        {
            User user = await _repository.GetSingleAsync<User>(u => u.UserName == userName);

            if (user == null)
            {
                return new UserResponse { ValidationErrorMessage = "Ususario no existe" };
            }

            var userDtos = _mapper.Map<UserDto>(user);

            return new UserResponse { Success = true, User = userDtos };
        }

        public async Task<UserResponse> UpdatePassword(AuthenticateUserRequest request)
        {
            User user = await _repository.GetSingleAsync<User>(u => u.UserName == request.UserName);

            if (user == null)
            {
                return new UserResponse { ValidationErrorMessage = "Ususario no existe" };
            }
            user.Password = AESEncryptor.Encrypt(request.Password);

            _repository.Update(user);
            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.UpdatePassword);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new UserResponse { Success = true };
        }

        public async Task<Response> RemoveUserAsync(DeleteUserRequest deleteUserRequest)
        {
            ThrowIf.Argument.IsNull(deleteUserRequest, nameof(deleteUserRequest));
            ThrowIf.Argument.IsZeroOrNegative(deleteUserRequest.UserId, nameof(deleteUserRequest.UserId));

            var user = await _repository.GetSingleAsync<User>(x => x.Id == deleteUserRequest.UserId);
            if (user == null) return new Response { Success = false, Message = "User not found" };

            await _repository.RemoveAsync(user);

            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(deleteUserRequest.RequestUserInfo, Transactions.DeleteUser);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }
    }
}
