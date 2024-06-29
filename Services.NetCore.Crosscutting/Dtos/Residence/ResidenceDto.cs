using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Account;
using Services.NetCore.Crosscutting.Dtos.SecurityManagement;
using Services.NetCore.Crosscutting.Dtos.UserDto;

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
        public UserByResidence Users { get; set; }
    }

    public class UserByResidence
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Block { get; set; }
        public string HouseNumber { get; set; }
      
    }
}
