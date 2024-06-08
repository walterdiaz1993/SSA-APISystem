using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Residence;

namespace Services.NetCore.Application.Services.ResidenceAppServices
{
    public interface IResidenceAppService
    {
        Task<Response> CreateOrUpdateResidenceAsync(ResidenceRequest request);
        Task<Response> RemoveResidenceAsync(DeleteResidenceRequest deleteResidenceRequest);
        Task<ResidenceResponse> GetResidencesAsync(string searchValue = null);
    }
}
