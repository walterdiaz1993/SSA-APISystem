using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.Payment.PaymentTypeAppServices;
using Services.NetCore.Crosscutting.Dtos.PaymentType;

namespace Services.NetCore.WebApi.Controllers.PaymentType
{
    [ApiController]
    [Route("api/v2/payment/payment-types")]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeAppService _paymentTypeAppService;
        public PaymentTypeController(IPaymentTypeAppService paymentTypeAppService)
        {
            _paymentTypeAppService = paymentTypeAppService;
        }

        [HttpPost]
        [Route("create-or-update-payment-type")]
        public async Task<IActionResult> CreateOrUpdatePaymentType(PaymentTypeRequest request)
        {
            var response = await _paymentTypeAppService.CreateOrUpdatePaymentTypeAsync(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("get-payment-types")]
        public async Task<IActionResult> GetPaymentTypes([FromQuery] string searchValue = null)
        {
            var response = await _paymentTypeAppService.GetPaymentTypesAsync(searchValue);

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove-payment-type")]
        public async Task<IActionResult> RemovePaymentType(DeletePaymentTypeRequest deletePaymentTypeRequest)
        {
            var response = await _paymentTypeAppService.DeleTePaymentTypeAsync(deletePaymentTypeRequest);

            return Ok(response);
        }
    }
}
