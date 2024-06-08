using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Aggregates.ResidenceAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.ResidentialAgg
{
    [Table(nameof(Residential_Transactions), Schema = SchemaTypes.Home)]
    public class Residential_Transactions : BaseEntity
    {
        [Required, StringLength(50)]
        public string Code { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required]
        public int Limit { get; set; }
        public bool? AllowEmergency { get; set; }

        [StringLength(50)]
        public string Color { get; set; }
        public virtual ICollection<Residence> Residences { get; set; }
    }
}
