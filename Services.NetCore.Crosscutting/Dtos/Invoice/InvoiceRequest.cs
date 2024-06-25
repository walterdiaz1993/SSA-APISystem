using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.Invoice
{
    public class DeleteInvoiceRequest : RequestBase
    {
        public int Id { get; set; }
    }
    public class InvoiceRequest : RequestBase
    {
        public InvoiceDto Invoice { get; set; }
    }
}
