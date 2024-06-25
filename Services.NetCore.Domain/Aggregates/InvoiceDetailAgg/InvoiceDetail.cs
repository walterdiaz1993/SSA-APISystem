using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Aggregates.InvoiceAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.InvoiceDetailAgg
{
    [Table(nameof(InvoiceDetail), Schema = SchemaTypes.Payment)]
    public class InvoiceDetail : BaseEntity
    {
        [Required, ForeignKey(nameof(InvoiceId))]
        public int InvoiceId { get; set; }

        [Required, StringLength(30)]
        public string PaymentTypeNo { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required, StringLength(200)]
        public string Description { get; set; }

        [Required, Column(TypeName = standardDecimal)]
        public decimal Cost { get; set; }

        [Required, Column(TypeName = standardDecimal)]
        public decimal Amount { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
