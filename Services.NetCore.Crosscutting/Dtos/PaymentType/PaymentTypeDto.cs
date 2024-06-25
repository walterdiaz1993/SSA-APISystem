using System.ComponentModel.DataAnnotations;
using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.PaymentType
{
    public class PaymentTypeResponse : ResponseBase
    {
        public List<PaymentTypeDto> PaymentTypes { get; set; }
    }
    public class PaymentTypeDto
    {
        public int ResidentialId { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public PaymentInterval PaymentInterval { get; set; }
        public int LatePayment { get; set; }
    }

    public enum PaymentInterval
    {
        Daily,
        Weekly,
        Middle,
        BiMonthly,
        TriMonthly,
        Yearly,
    }
}
