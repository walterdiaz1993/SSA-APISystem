using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.SecurityManagerAggs
{
    [Table(nameof(UserRole), Schema = SchemaTypes.SecurityManagement)]
    public class UserRole : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }

        [Required]
        [ForeignKey(nameof(PermissionId))]
        public int PermissionId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
