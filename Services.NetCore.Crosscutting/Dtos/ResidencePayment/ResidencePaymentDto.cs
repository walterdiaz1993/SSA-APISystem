using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.ResidencePayment
{
    public class ResidencePaymentResponse : ResponseBase
    {
        public List<ResidencePaymentDto> ResidencePayments { get; set; }
    }

    public class CreateResidencePaymentDto
    {
        public int ResidenceId { get; set; }
        public DateTime? InitialPaymentDate { get; set; }
    }
    public class ResidencePaymentDto : BaseDto
    {
        public string PaymentNo { get; set; }
        public int ResidenceId { get; set; }
        public DateTime InitialPaymentDate { get; set; }
    }
}
