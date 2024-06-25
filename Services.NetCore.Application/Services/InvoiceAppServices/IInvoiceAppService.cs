using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Invoice;

namespace Services.NetCore.Application.Services.InvoiceAppServices
{
    public interface IInvoiceAppService
    {
        Task<InvoiceResponse> CreateOrUpdateInvoiceAsync(InvoiceRequest invoiceRequest);
        Task<Response> DeleteAsync(DeleteInvoiceRequest invoiceRequest);
        Task<InvoiceResponse> GetInvoices(string searchValue = null);
    }
}
