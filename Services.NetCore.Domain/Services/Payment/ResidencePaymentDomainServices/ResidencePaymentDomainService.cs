using Services.NetCore.Crosscutting.Dtos.ResidencePayment;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Services.Payment.ResidencePaymentDomainServices
{
    public class ResidencePaymentDomainService : IResidencePaymentDomainService
    {
        public DomainValidationErrors ValidateResidencePayment(CreateResidencePaymentRequest createResidencePaymentRequest)
        {
            if (createResidencePaymentRequest.Residences == null || !createResidencePaymentRequest.Residences.Any())
            {
                return new DomainValidationErrors("La lista de residencias no debe ser vacía o nula");
            }

            foreach (var item in createResidencePaymentRequest.Residences)
            {
                if (item.ResidenceId == 0)
                {
                    return new DomainValidationErrors($"La residenciaId {item.ResidenceId} es inválida");
                }

                if (!item.InitialPaymentDate.HasValue)
                {
                    return new DomainValidationErrors($"La fecha del pago initial es requerida");
                }
            }

            if (string.IsNullOrEmpty(createResidencePaymentRequest.PaymentNo))
            {
                return new DomainValidationErrors("El tipo de pago no debe ser vacío o nulo");
            }

            return null;
        }
    }
}
