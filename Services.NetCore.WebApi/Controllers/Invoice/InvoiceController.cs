using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.InvoiceAppServices;
using Services.NetCore.Crosscutting.Dtos.Invoice;

namespace Services.NetCore.WebApi.Controllers.Invoice
{
    [ApiController]
    [Route("api/v2/payment/invoices")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceAppService _invoiceAppService;

        public InvoiceController(IInvoiceAppService invoiceAppService)
        {
            _invoiceAppService = invoiceAppService;
        }



        [HttpGet, Route("")]
        public async Task<IActionResult> GetInvoices([FromQuery] string searchValue)
        {
            var response = await _invoiceAppService.GetInvoices(searchValue);

            return Ok(response);
        }

        [HttpPost, Route("save-invoice")]
        public async Task<IActionResult> SaveInvoice(InvoiceRequest invoiceRequest)
        {
            var response = await _invoiceAppService.CreateOrUpdateInvoiceAsync(invoiceRequest);

            return Ok(response);
        }

        [HttpDelete, Route("delete-invoice")]
        public async Task<IActionResult> DeleteInvoice(DeleteInvoiceRequest deleteInvoiceRequest)
        {
            var response = await _invoiceAppService.DeleteAsync(deleteInvoiceRequest);

            return Ok(response);
        }
    }
}
