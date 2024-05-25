using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Account;
using Services.NetCore.Crosscutting.Dtos.UserDto;
using Services.NetCore.Domain.Aggregates.AccountAgg;
using Services.NetCore.Domain.Aggregates.UserAgg;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Infraestructure.Mapping.Security
{
    public class SecurityProfile : GenericProfileBase<BaseEntity, ResponseBase>
    {
        public SecurityProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();
        }
    }
}
