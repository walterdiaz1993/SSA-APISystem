using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.ResidencePayment
{
    public class ResidencePaymentRequest : RequestBase
    {
        public ResidencePaymentDto ResidencePayment { get; set; }
    }

    public class CreateResidencePaymentRequest : RequestBase
    {
        public string PaymentNo { get; set; }
        public List<CreateResidencePaymentDto> Residences { get; set; }
    }

    public class DeleteResidencePaymentRequest : RequestBase
    {
        public int Id { get; set; }
    }

}
