using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.Residence
{
    public class ResidenceRequest : RequestBase
    {
        public ResidenceDto Residence { get; set; }
    }

    public class DeleteResidenceRequest : RequestBase
    {
        public int Id { get; set; }
    }
}
