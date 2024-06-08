using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Residence;
using Services.NetCore.Crosscutting.Dtos.Residential;

namespace Services.NetCore.Application.Services.ResidenceAppServices
{
    public interface IResidentialAppService
    {
        Task<Response> CreateOrUpdateResidentialAsync(ResidentialRequest request);
        Task<Response> RemoveResidentialAsync(DeleteResidentialRequest deleteResidentialRequest);
        Task<ResidentialResponse> GetResidentialsAsync(string searchValue = null);
    }
}
