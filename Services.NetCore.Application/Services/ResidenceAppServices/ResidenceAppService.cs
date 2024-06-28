using AutoMapper;
using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Residence;
using Services.NetCore.Domain.Aggregates.ResidenceAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.ResidenceAppServices
{
    public class ResidenceAppService : BaseAppService, IResidenceAppService
    {
        private readonly IMapper _mapper;
        public ResidenceAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<Response> CreateOrUpdateResidenceAsync(ResidenceRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.Residence, nameof(request.Residence));

            var existingResidence = await _repository.GetSingleAsync<Residence>(r => r.Id == request.Residence.Id);
            TransactionInfo transactionInfo;

            if (existingResidence != null)
            {
                existingResidence.ResidentialName = request.Residence.ResidentialName;
                existingResidence.Name = request.Residence.Name;
                existingResidence.Block = request.Residence.Block;
                existingResidence.HouseNumber = request.Residence.HouseNumber;
                existingResidence.Color = request.Residence.Color;

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.UpdateResidence);
            }
            else
            {
                var newResidence = _mapper.Map<Residence>(request.Residence);

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.CreateResidence);
                await _repository.AddAsync(newResidence);
            }

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<ResidenceResponse> GetResidencesAsync(string searchValue = null)
        {
            IEnumerable<Residence> residences;

            if (!string.IsNullOrEmpty(searchValue))
            {
                var residentialId = Convert.ToInt32(searchValue);
                residences = residentialId > 0 ? await _repository.GetFilteredAsync<Residence>(r => r.ResidentialId == residentialId) : 
                                                await _repository.GetFilteredAsync<Residence>(r => r.Name.Contains(searchValue) ||
                                                                               r.ResidentialName.Contains(searchValue));
            }
            else
            {
                residences = await _repository.GetAllAsync<Residence>();
            }

            var residenceDtos = _mapper.Map<List<ResidenceDto>>(residences);

            return new ResidenceResponse { Success = true, Residences = residenceDtos };
        }

        public async Task<Response> RemoveResidenceAsync(DeleteResidenceRequest deleteResidenceRequest)
        {
            ThrowIf.Argument.IsNull(deleteResidenceRequest, nameof(deleteResidenceRequest));
            ThrowIf.Argument.IsZeroOrNegative(deleteResidenceRequest.Id, nameof(deleteResidenceRequest.Id));

            var residence = await _repository.GetSingleAsync<Residence>(r => r.Id == deleteResidenceRequest.Id);
            if (residence == null) return new Response { Success = false, Message = Setting.residenceDoesntExist };

            await _repository.RemoveAsync(residence);

            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(deleteResidenceRequest.RequestUserInfo, Transactions.DeleteResidence);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }
    }
}
