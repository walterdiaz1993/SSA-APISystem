using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.Account
{
    public class AccountRequest : RequestBase
    {
        public AccountDto Account { get; set; }
    }

    public class DeleteAccountRequest : RequestBase
    {
        public int AccountId { get; set; }
    }
}
