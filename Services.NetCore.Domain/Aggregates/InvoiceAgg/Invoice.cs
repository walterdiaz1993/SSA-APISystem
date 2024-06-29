using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Aggregates.InvoiceDetailAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.InvoiceAgg
{
    [Table(nameof(Invoice), Schema = SchemaTypes.Payment)]
    public class Invoice : BaseEntity
    {
        [Required, StringLength(30)]
        public string InvoiceNo { get; set; }

        [Required, StringLength(200)]
        public string DepositNo { get; set; }
        public int AccountId { get; set; }

        [Required, StringLength(500)]
        public string Comments { get; set; }

        [Required, Column(TypeName = standardDecimal)]
        public decimal Total { get; set; }
        public int ResidenceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Customer { get; set; }
        public string Block { get; set; }
        public string HouseNumber { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
