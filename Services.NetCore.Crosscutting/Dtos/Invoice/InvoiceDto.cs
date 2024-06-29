using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.Invoice
{
    public class InvoiceResponse : ResponseBase
    {
        public InvoiceDto Invoice { get; set; }
        public List<InvoiceDto> Invoices { get; set; }
    }
    public class InvoiceDto
    {
        public string InvoiceNo { get; set; }
        public string DepositNo { get; set; }
        public int AccountId { get; set; }
        public string Customer { get; set; }
        public string Block { get; set; }
        public string HouseNumber { get; set; }
        public string Comments { get; set; }
        public decimal Total { get; set; }
        public int ResidenceId { get; set; }
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }

        public List<InvoiceDetailDto> InvoiceDetail { get; set; }
    }
}
