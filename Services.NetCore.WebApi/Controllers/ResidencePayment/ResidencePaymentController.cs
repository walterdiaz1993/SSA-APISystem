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


        [HttpGet, Route("")]
        public async Task<IActionResult> GetResidencePaymentByResidenceId([FromQuery] int residenceId)
        {
            var response = await _residencePaymentAppService.GetResidencePayments(residenceId);

            return Ok(response);
        }

        [HttpPost, Route("create-residence-payment")]
        public async Task<IActionResult> CreateResidencePayment(CreateResidencePaymentRequest createResidencePaymentRequest)
        {
            var response = await _residencePaymentAppService.CreateResidencePayment(createResidencePaymentRequest);

            return Ok(response);
        }

        [HttpDelete, Route("delete-residence-payment")]
        public async Task<IActionResult> DeleteResidencePayment(DeleteResidencePaymentRequest deleteResidencePaymentRequest)
        {
            var response = await _residencePaymentAppService.DeleteResidencePayment(deleteResidencePaymentRequest);

            return Ok(response);
        }
    }
}
