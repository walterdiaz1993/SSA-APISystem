using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Aggregates.ResidentialAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.ResidenceAgg
{
    [Table(nameof(Residence), Schema = SchemaTypes.Home)]
    public class Residence : BaseEntity
    {
        [ForeignKey(nameof(ResidentialId))]
        public int ResidentialId { get; set; }

        [Required, StringLength(150)]
        public string ResidentialName { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(20)]
        public string Block { get; set; }

        [Required, StringLength(20)]
        public string HouseNumber { get; set; }

        [Required, StringLength(50)]
        public string Color { get; set; }

        public virtual Residential Residential { get; set; }
    }
}
