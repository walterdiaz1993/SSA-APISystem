using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.ResidencePayment;

namespace Services.NetCore.Application.Services.Payment.ResidencePaymentAppServices
{
    public interface IResidencePaymentAppService
    {
        Task<Response> CreateResidencePayment(CreateResidencePaymentRequest request);
        Task<Response> DeleteResidencePayment(DeleteResidencePaymentRequest deleteResidencePaymentRequest);
        Task<ResidencePaymentResponse> GetResidencePayments(int residenceId);
    }
}
