using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Residential;

namespace Services.NetCore.Crosscutting.Dtos.Residence
{
    public class ResidentialRequest : RequestBase
    {
        public ResidentialDto Residential { get; set; }
    }

    public class DeleteResidentialRequest : RequestBase
    {
        public int Id { get; set; }
    }
}
