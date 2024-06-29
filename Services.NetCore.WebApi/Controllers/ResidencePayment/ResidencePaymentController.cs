using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.Payment.ResidencePaymentAppServices;
using Services.NetCore.Crosscutting.Dtos.ResidencePayment;

namespace Services.NetCore.WebApi.Controllers.ResidencePayment
{
    [ApiController]
    [Route("api/v2/payment/residences-payments")]
    public class ResidencePaymentController : ControllerBase
    {
        private IResidencePaymentAppService _residencePaymentAppService;

        public ResidencePaymentController(IResidencePaymentAppService residencePaymentAppService)
        {
            _residencePaymentAppService = residencePaymentAppService;
        }

        [HttpPost, Route("create-residence-payment")]
        public async Task<IActionResult> CreateResidencePayment(CreateResidencePaymentRequest createResidencePaymentRequest)
        {
            var response = await _residencePaymentAppService.CreateResidencePayment(createResidencePaymentRequest);

            return Ok(response);
        }
    }
}
