using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Invoice;
using Services.NetCore.Crosscutting.Dtos.PaymentType;
using Services.NetCore.Domain.Aggregates.InvoiceAgg;
using Services.NetCore.Domain.Aggregates.InvoiceDetailAgg;
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
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<InvoiceDetail, InvoiceDetailDto>();
            CreateMap<InvoiceDetailDto, InvoiceDetail>();
        }
    }
}
