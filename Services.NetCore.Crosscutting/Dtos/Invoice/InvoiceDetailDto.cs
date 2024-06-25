namespace Services.NetCore.Crosscutting.Dtos.Invoice
{
    public class InvoiceDetailDto
    {
        public int InvoiceId { get; set; }
        public string PaymentTypeNo { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Amount { get; set; }
        public int Id { get; set; }
    }
}
