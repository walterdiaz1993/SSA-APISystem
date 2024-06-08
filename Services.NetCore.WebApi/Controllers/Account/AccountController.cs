using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.AccountAppServices;
using Services.NetCore.Crosscutting.Dtos.Account;
using System.Threading.Tasks;

namespace Services.NetCore.WebApi.Controllers.Account
{
    [ApiController]
    [Route("api/v2/security/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpPost]
        [Route("create-or-update-account")]
        public async Task<IActionResult> CreateOrUpdateAccount(AccountRequest request)
        {
            var response = await _accountAppService.CreateOrUpdateAccountAsync(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAccounts([FromQuery] string searchValue = null)
        {
            var response = await _accountAppService.GetAccountsAsync(searchValue);

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove-account")]
        public async Task<IActionResult> RemoveAccount(DeleteAccountRequest deleteAccountRequest)
        {
            var response = await _accountAppService.RemoveAccountAsync(deleteAccountRequest);

            return Ok(response);
        }

        [HttpPost]
        [Route("enable-or-disable-massives-accounts")]
        public async Task<IActionResult> DisableAccountsByIdsAsync(DisableOrEnableAccountRequest disableOrEnableAccountRequest)
        {
            var response = await _accountAppService.DisableAccountsByIdsAsync(disableOrEnableAccountRequest);

            return Ok(response);
        }
    }

}
