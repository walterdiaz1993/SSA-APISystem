using Microsoft.AspNetCore.Mvc;
using Services.NetCore.Application.Services.ResidenceAppServices;
using Services.NetCore.Crosscutting.Dtos.Residence;
using System.Threading.Tasks;

namespace Services.NetCore.WebApi.Controllers.Residential
{
    [ApiController]
    [Route("api/v2/security/residentials")]
    public class ResidentialController : ControllerBase
    {
        private readonly IResidentialAppService _residentialAppService;

        public ResidentialController(IResidentialAppService residentialAppService)
        {
            _residentialAppService = residentialAppService;
        }

        [HttpPost]
        [Route("create-or-update-residential")]
        public async Task<IActionResult> CreateOrUpdateResidential(ResidentialRequest request)
        {
            var response = await _residentialAppService.CreateOrUpdateResidentialAsync(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("get-residentials")]
        public async Task<IActionResult> GetResidentials([FromQuery] string searchValue = null)
        {
            var response = await _residentialAppService.GetResidentialsAsync(searchValue);

            return Ok(response);
        }

        [HttpDelete]
        [Route("remove-residential")]
        public async Task<IActionResult> RemoveResidential(DeleteResidentialRequest deleteResidentialRequest)
        {
            var response = await _residentialAppService.RemoveResidentialAsync(deleteResidentialRequest);

            return Ok(response);
        }
    }

}
