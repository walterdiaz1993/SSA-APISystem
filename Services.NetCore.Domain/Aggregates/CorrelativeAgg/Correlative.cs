using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.CorrelativeAgg
{
    [Table(nameof(Correlative), Schema = SchemaTypes.Commons)]
    public class Correlative : BaseEntity
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

        public string GetNextCorrelative()
        {
            int lastNumber = int.Parse(LastNumber.Trim()) + 1;

            LastNumber = lastNumber.ToString(string.Format("D{0}", Length)).Trim();

            string nextCorrelative = string.Format("{0}{1}", Type, LastNumber);

            return nextCorrelative;
        }
    }
}
