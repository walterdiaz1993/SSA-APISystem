using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.SecurityManagerAggs
{
    [Table(nameof(Permission_Transactions), Schema = SchemaTypes.SecurityManagement)]
    public class Permission_Transactions : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsGranted { get; set; }

        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }
    }
}
