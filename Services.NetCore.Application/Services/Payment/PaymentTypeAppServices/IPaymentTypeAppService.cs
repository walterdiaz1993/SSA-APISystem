using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.PaymentType;

namespace Services.NetCore.Application.Services.Payment.PaymentTypeAppServices
{
    public interface IPaymentTypeAppService
    {
        Task<Response> CreateOrUpdatePaymentTypeAsync(PaymentTypeRequest paymentTypeRequest);
        Task<Response> DeleTePaymentTypeAsync(DeletePaymentTypeRequest deletePaymentTypeRequest);
        Task<PaymentTypeResponse> GetPaymentTypesAsync(string searchValue = null);
    }
}
