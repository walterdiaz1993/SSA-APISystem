using AutoMapper;
using Services.NetCore.Application.Core;
using Services.NetCore.Application.Services.ResidenceAppServices;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Residence;
using Services.NetCore.Crosscutting.Dtos.Residential;
using Services.NetCore.Domain.Aggregates.ResidentialAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.ResidentialAppServices
{
    public class ResidentialAppService : BaseAppService, IResidentialAppService
    {
        private readonly IMapper _mapper;
        public ResidentialAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<Response> CreateOrUpdateResidentialAsync(ResidentialRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.Residential, nameof(request.Residential));

            var existingResidential = await _repository.GetSingleAsync<Residential>(r => r.Id == request.Residential.Id);
            TransactionInfo transactionInfo;

            if (existingResidential != null)
            {
                existingResidential.Code = request.Residential.Code;
                existingResidential.Name = request.Residential.Name;
                existingResidential.Limit = request.Residential.Limit;
                existingResidential.AllowEmergency = request.Residential.AllowEmergency;
                existingResidential.Color = request.Residential.Color;

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.UpdateResidential);
            }
            else
            {
                var newResidential = _mapper.Map<Residential>(request.Residential);

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.CreateResidential);
                await _repository.AddAsync(newResidential);
            }

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<Response> RemoveResidentialAsync(DeleteResidentialRequest deleteResidentialRequest)
        {
            ThrowIf.Argument.IsNull(deleteResidentialRequest, nameof(deleteResidentialRequest));
            ThrowIf.Argument.IsZeroOrNegative(deleteResidentialRequest.Id, nameof(deleteResidentialRequest.Id));

            var residential = await _repository.GetSingleAsync<Residential>(r => r.Id == deleteResidentialRequest.Id);
            if (residential == null) return new Response { Success = false, Message = Setting.residentialDoesntExist };

            await _repository.RemoveAsync(residential);

            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(deleteResidentialRequest.RequestUserInfo, Transactions.DeleteResidential);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<ResidentialResponse> GetResidentialsAsync(string searchValue = null)
        {
            IEnumerable<Residential> residentials;

            if (!string.IsNullOrEmpty(searchValue))
            {
                residentials = await _repository.GetFilteredAsync<Residential>(r => r.Name.Contains(searchValue) ||
                                                                                   r.Code.Contains(searchValue));
            }
            else
            {
                residentials = await _repository.GetAllAsync<Residential>();
            }

            var residentialDtos = _mapper.Map<List<ResidentialDto>>(residentials);

            return new ResidentialResponse { Success = true, Residentials = residentialDtos };
        }

    }
}
