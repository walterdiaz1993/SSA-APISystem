using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.ResidenceAppServices;
using Services.NetCore.Crosscutting.Dtos.Residence;

namespace Services.NetCore.WebApi.Controllers.Residence
{
    [ApiController]
    [Route("api/v2/security/residences")]
    public class ResidenceController : ControllerBase
    {
        private readonly IResidenceAppService _residenceAppService;

        public ResidenceController(IResidenceAppService residenceAppService)
        {
            _residenceAppService = residenceAppService;
        }

        [HttpPost]
        [Route("create-or-update-residence")]
        public async Task<IActionResult> CreateOrUpdateResidence(ResidenceRequest request)
        {
            var response = await _residenceAppService.CreateOrUpdateResidenceAsync(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("get-residences")]
        public async Task<IActionResult> GetResidences([FromQuery] string searchValue = null)
        {
            var response = await _residenceAppService.GetResidencesAsync(searchValue);

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove-residence")]
        public async Task<IActionResult> RemoveResidence(DeleteResidenceRequest deleteResidenceRequest)
        {
            var response = await _residenceAppService.RemoveResidenceAsync(deleteResidenceRequest);

            return Ok(response);
        }
    }
}
