using Services.NetCore.Crosscutting.Dtos.ResidencePayment;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Services.Payment.ResidencePaymentDomainServices
{
    public interface IResidencePaymentDomainService
    {
        DomainValidationErrors ValidateResidencePayment(CreateResidencePaymentRequest createResidencePaymentRequest);
    }
}
