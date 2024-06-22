using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.PaymentType;
using Services.NetCore.Domain.Aggregates.PaymentTypeAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Infraestructure.Mapping.Payment
{
    public class PaymentProfile : GenericProfileBase<BaseEntity, ResponseBase>
    {
        public PaymentProfile()
        {
            CreateMap<PaymentType, PaymentTypeDto>();
            CreateMap<PaymentTypeDto, PaymentType>();
        }
    }
}
