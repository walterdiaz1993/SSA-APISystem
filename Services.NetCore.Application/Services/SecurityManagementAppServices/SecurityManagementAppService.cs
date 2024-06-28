using AutoMapper;
using Azure.Core;
using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.SecurityManagement;
using Services.NetCore.Domain.Aggregates.SecurityManagerAggs;
using Services.NetCore.Domain.Aggregates.UserAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.SecurityManagementAppServices
{
    public class SecurityManagementAppService : BaseAppService, ISecurityManagementAppService
    {
        private readonly IMapper _mapper;
        public SecurityManagementAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<ResponseBase> CreateOrUpdatePermission(PermissionRequest request)
        {
            Permission permission = await _repository.GetSingleAsync<Permission>(p => p.Id == request.Id);
            TransactionInfo transactionInfo;

            if (permission == null)
            {
                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.CreatePermission);

                permission = new Permission
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsGranted = request.IsGranted,
                    RoleId = request.RoleId,
                };

                _repository.Add(permission);
            }
            else
            {
                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.UpdatePermission);

                permission.Name = request.Name;
                permission.Description = request.Description;
                permission.IsGranted = request.IsGranted;
                permission.RoleId = request.RoleId;
                permission.ModifiedBy = request.RequestUserInfo.ModifiedBy;

                _repository.Update(permission);
            }



            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new ResponseBase { Success = true };
        }

        public async Task<ResponseBase> CreateOrUpdateRole(RoleRequest request)
        {
            Role role = await _repository.GetSingleAsync<Role>(p => p.Id == request.Role.Id);
            TransactionInfo transactionInfo;
            if (role == null)
            {
                role = _mapper.Map<Role>(request.Role);
                role.Permissions = null;
                await _repository.AddAsync(role);
                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.CreateRole);
            }
            else
            {
                role.Name = request.Role.Name;
                role.Description = request.Role.Description;

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.UpdateRole);
            }

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new ResponseBase { Success = true };
        }

        public async Task<ResponseBase> DeletePermission(PermissionRequest request)
        {
            if (request.Id > 0)
            {
                await _repository.RemoveAsync<Permission>(u => u.Id == request.Id);
                var transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.DeletePermission);

                await _repository.UnitOfWork.CommitAsync(transactionInfo);

                return new ResponseBase { Success = true };
            }

            return new ResponseBase { Success = true, ValidationErrorMessage = Setting.permissionDoesnExist };
        }

        public async Task<ResponseBase> DeleteRole(RoleRequest request)
        {
            if (request.Role.Id > 0)
            {
                await _repository.RemoveAsync<Role>(u => u.Id == request.Role.Id);
                var transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.DeleteRole);

                await _repository.UnitOfWork.CommitAsync(transactionInfo);

                return new ResponseBase { Success = true };
            }

            return new ResponseBase { Success = true, ValidationErrorMessage = Setting.roleDoesntExist };
        }

        public async Task<RolesResponse> GetAllRoles()
        {
            List<string> includes = new List<string> { "Permissions" };

            IEnumerable<Role> roles = await _repository.GetAllIncludeAsync<Role>(includes);
            if (roles.Any())
            {
                var rolesDto = _mapper.Map<List<RoleDto>>(roles);

                return new RolesResponse { Roles = rolesDto, Success = true };
            }

            return new RolesResponse { Roles = new List<RoleDto>(), Success = false };
        }

        public async Task<List<AccessesDto>> GetAccessesByUserName(string userName)
        {
            User user = await _repository.GetSingleAsync<User>(u => u.UserName == userName);

            if (user != null)
            {
                var userRoles = await _repository.GetFilteredAsync<UserRole>(x => x.UserId == user.Id);
                var permissionsIds = userRoles.Select(x => x.PermissionId).ToList();
                var permissions = await _repository.GetFilteredAsync<Permission>(x => x.IsGranted && permissionsIds.Contains(x.Id));
                var roleIds = userRoles.Select(x => x.RoleId).ToList();
                var roles = await _repository.GetFilteredAsync<Role>(x => roleIds.Contains(x.Id));

                List<AccessesDto> accesses = (from userRole in userRoles
                                              join role in roles on userRole.RoleId equals role.Id
                                              join permission in permissions on userRole.PermissionId equals permission.Id
                                              group role by new { role.Id, RolName = role.Name } into summary
                                              select new AccessesDto
                                              {
                                                  RoleId = summary.Key.Id,
                                                  RolName = summary.Key.RolName,
                                                  UserName = user.UserName,
                                                  UserId = user.Id,
                                                  Permissions = summary.SelectMany(x => x.Permissions).DistinctBy(x => x.Id).Select(x => new PermissionDto
                                                  {
                                                      Id = x.Id,
                                                      Name = x.Name,
                                                      Description = x.Description,
                                                      IsGranted = x.IsGranted,
                                                      RoleId = summary.Key.Id
                                                  }).ToList()
                                              }).ToList();

                return accesses;
            }

            return null;
        }

        public async Task<ResponseBase> ProvideAccesess(UserRoleRequest request)
        {
            if (request == null) throw new Exception("Request shouldn't be null" + request);

            var transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.ProvideAccess);
            List<int> permissions = request.RolesPermissions.Select(r => r.PermissionId).ToList();
            List<int> roles = request.RolesPermissions.Select(r => r.RoleId).ToList();

            List<UserRole> userRoles = new List<UserRole>();

            foreach (int item in request.UsersIds)
            {
                foreach (var rolePermissionDto in request.RolesPermissions)
                {
                    UserRole userRole = new UserRole
                    {
                        RoleId = rolePermissionDto.RoleId,
                        PermissionId = rolePermissionDto.PermissionId,
                        UserId = item,
                    };

                    await _repository.AddAsync(userRole);
                }
            }
            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new ResponseBase { Success = true };
        }

        public async Task<ResponseBase> RemoveAccessPermissionToUser(int id, int userId, UserInfoDto requestUserInfo)
        {
            await _repository.RemoveAsync<UserRole>(x => x.PermissionId == id && x.UserId == userId);

            var transactionInfo = TransactionInfoFactory.CreateTransactionInfo(requestUserInfo, Transactions.DeleteAccessPermissionToUser);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new ResponseBase { Success = true };
        }

        public async Task<ResponseBase> RemoveAccessRoleToUser(int id, int userId, UserInfoDto requestUserInfo)
        {
            await _repository.RemoveRangeAsync<UserRole>(x => x.RoleId == id && x.UserId == userId);

            var transactionInfo = TransactionInfoFactory.CreateTransactionInfo(requestUserInfo, Transactions.RemoveAccessRoleToUser);
            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new ResponseBase { Success = true };
        }
    }
}
