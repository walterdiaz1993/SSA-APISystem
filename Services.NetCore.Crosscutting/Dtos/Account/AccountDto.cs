using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.Account
{
    public class AccountResponse : ResponseBase
    {
        public AccountDto Account { get; set; }
        public List<AccountDto> Accounts { get; set; }
    }
    public class AccountDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Residence { get; set; }
        public string AccountType { get; set; }
        public string Residential { get; set; }
        public string Block { get; set; }
        public string HouseNumber { get; set; }
        public int ResidentialId { get; set; }
        public int ResidenceId { get; set; }
        public bool AllowEmergy { get; set; }
        public string LockCode { get; set; }
        public int UserId { get; set; }
    }
}
