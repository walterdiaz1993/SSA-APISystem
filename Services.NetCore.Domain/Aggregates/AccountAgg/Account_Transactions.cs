using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Aggregates.UserAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.AccountAgg
{
    [Table(nameof(Account_Transactions), Schema = SchemaTypes.Security)]
    public class Account_Transactions : BaseEntity
    {
        [StringLength(100), Required]
        public string FullName { get; set; }

        [StringLength(100), Required]
        public string Email { get; set; }

        [StringLength(50), Required]
        public string PhoneNumber { get; set; }

        [StringLength(150), Required]
        public string Residence { get; set; }

        [StringLength(10), Required]
        public string AccountType { get; set; }

        [StringLength(100), Required]
        public string Residential { get; set; }

        [StringLength(10), Required]
        public string Block { get; set; }

        [StringLength(20), Required]
        public string HouseNumber { get; set; }
        public int ResidentialId { get; set; }
        public int ResidenceId { get; set; }
        public bool AllowEmergy { get; set; }

        [StringLength(50)]
        public string LockCode { get; set; }

        public int UserId { get; set; }
    }
}
