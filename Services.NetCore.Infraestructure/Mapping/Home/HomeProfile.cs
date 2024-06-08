using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Residence;
using Services.NetCore.Crosscutting.Dtos.Residential;
using Services.NetCore.Domain.Aggregates.ResidenceAgg;
using Services.NetCore.Domain.Aggregates.ResidentialAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Infraestructure.Mapping.Home
{
    public class HomeProfile : GenericProfileBase<BaseEntity, ResponseBase>
    {
        public HomeProfile()
        {
            CreateMap<Residential, ResidentialDto>();
            CreateMap<ResidentialDto, Residential>();
            CreateMap<Residence, ResidenceDto>();
            CreateMap<ResidenceDto, Residence>();
        }
    }
}
