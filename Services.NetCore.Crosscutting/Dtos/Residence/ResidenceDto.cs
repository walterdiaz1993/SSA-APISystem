using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.Residence
{
    public class ResidenceResponse : ResponseBase
    {
        public ResidenceDto Residence { get; set; }
        public List<ResidenceDto> Residences { get; set; }
    }
    public class ResidenceDto
    {
        public int Id { get; set; }
        public int ResidentialId { get; set; }
        public string ResidentialName { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public string HouseNumber { get; set; }
        public string Color { get; set; }
    }
}
