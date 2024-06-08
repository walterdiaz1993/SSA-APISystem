using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.SecurityManagerAggs
{
    [Table(nameof(Role), Schema = SchemaTypes.SecurityManagement)]
    public class Role : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
