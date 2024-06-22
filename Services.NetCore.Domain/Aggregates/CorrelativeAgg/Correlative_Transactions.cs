using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates
{
    [Table(nameof(Correlative_Transactions), Schema = SchemaTypes.Commons)]
    public class Correlative_Transactions : BaseEntity
    {
        [Required, StringLength(100)]
        public string Description { get; set; }

        [Required, Column(TypeName = "char(15)")]
        public string LastNumber { get; set; }

        [Required]
        public int Length { get; set; }
        public bool FirstIsApha { get; set; }

        [StringLength(5)]
        public string Type { get; set; }
    }
}
