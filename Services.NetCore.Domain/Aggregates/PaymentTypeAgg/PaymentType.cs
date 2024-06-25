using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Dtos.PaymentType;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Aggregates.ResidentialAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.PaymentTypeAgg
{
    [Table(nameof(PaymentType), Schema = SchemaTypes.Payment)]
    public class PaymentType : BaseEntity
    {
        [Required, StringLength(30)]
        public string PaymentTypeNo { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(longVarcharLength)]
        public string Description { get; set; }

        [Required, Column(TypeName = standardDecimal)]
        public decimal Cost { get; set; }

        [Required]
        public PaymentInterval PaymentInterval { get; set; }

        [ForeignKey(nameof(ResidentialId))]
        public int ResidentialId { get; set; }

        [Required]
        public int LatePayment { get; set; }

        public virtual Residential Residential { get; set; }
    }
}
