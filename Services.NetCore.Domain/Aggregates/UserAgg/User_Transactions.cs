using Services.NetCore.Crosscutting.Resources;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Services.NetCore.Domain.Aggregates.UserAgg
{
    [Table(nameof(User_Transactions), Schema = SchemaTypes.Security)]
    public class User_Transactions : BaseEntity
    {
        [StringLength(50), Required]
        public string UserName { get; set; }

        [StringLength(100), Required]
        public string Password { get; set; }
        public string Device { get; set; }
        public string DeviceId { get; set; }

        [StringLength(150), Required]
        public string Residential { get; set; }

        [StringLength(50), Required]
        public string Gender { get; set; }
    }
}
