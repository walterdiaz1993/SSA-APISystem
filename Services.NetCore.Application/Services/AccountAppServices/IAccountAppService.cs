using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Account;

namespace Services.NetCore.Application.Services.AccountAppServices
{
    public interface IAccountAppService
    {
        Task<Response> CreateOrUpdateAccountAsync(AccountRequest request);
        Task<Response> RemoveAccountAsync(DeleteAccountRequest deleteUserRequest);
        Task<AccountResponse> GetAccountsAsync(string searchValue = null);
        Task<Response> DisableAccountsByIdsAsync(DisableOrEnableAccountRequest disableOrEnableAccountRequest);
    }
}
