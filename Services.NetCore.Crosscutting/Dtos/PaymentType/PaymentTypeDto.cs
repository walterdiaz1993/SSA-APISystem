using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.PaymentType
{
    public class PaymentTypeResponse: ResponseBase
    {
        public List<PaymentTypeDto> PaymentTypes { get; set; }
    }
    public class PaymentTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public PaymentInterval PaymentInterval { get; set; }
    }

    public enum PaymentInterval
    {
        Daily,
        Monthly,
        Yearly
    }
}
