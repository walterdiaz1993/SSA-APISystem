using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Crosscutting.Dtos.Residential
{
    public class ResidentialResponse : ResponseBase
    {
        public ResidentialDto Residential { get; set; }
        public List<ResidentialDto> Residentials { get; set; }
    }
    public class ResidentialDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Limit { get; set; }
        public bool? AllowEmergency { get; set; }
        public string Color { get; set; }
    }
}
