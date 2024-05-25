using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Account;
using Services.NetCore.Crosscutting.Dtos.UserDto;

namespace Services.NetCore.Application.Services.AccountAppServices
{
    public interface IAccountAppService
    {
        Task<Response> CreateOrUpdateAccountAsync(AccountRequest request);
        Task<Response> RemoveAccountAsync(DeleteAccountRequest deleteUserRequest);
        Task<AccountResponse> GetAccountsAsync(string searchValue = null);
    }
}
