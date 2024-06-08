using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.SecurityManagement;
using Services.NetCore.Domain.Aggregates.SecurityManagerAggs;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Infraestructure.Mapping.SecurityManagement
{
    public class SecurityManagementProfile : GenericProfileBase<BaseEntity, ResponseBase>
    {
        public SecurityManagementProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();
        }
    }
}
