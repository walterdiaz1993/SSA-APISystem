using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.NetCore.Crosscutting.Resources;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Aggregates.InvoiceAgg
{
    [Table(nameof(Invoice_Transactions), Schema = SchemaTypes.Payment)]
    public class Invoice_Transactions : BaseEntity
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
    }
}
