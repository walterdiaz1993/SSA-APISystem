using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.PaymentType
{
    public class PaymentTypeRequest: RequestBase
    {
        public PaymentTypeDto PaymentType { get; set; }
    }

    public class DeletePaymentTypeRequest: RequestBase
    {
        public int Id { get; set; }
    }
}
