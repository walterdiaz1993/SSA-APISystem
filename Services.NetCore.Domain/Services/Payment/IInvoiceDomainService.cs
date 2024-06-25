using Services.NetCore.Crosscutting.Dtos.Invoice;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Services.Payment
{
    public interface IInvoiceDomainService
    {
        DomainExceptionError ValidateInvoice(InvoiceDto invoice);
    }
}
