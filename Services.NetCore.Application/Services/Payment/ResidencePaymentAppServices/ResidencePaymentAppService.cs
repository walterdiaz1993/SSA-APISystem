using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.ResidencePayment;
using Services.NetCore.Domain.Aggregates.ResidencePaymentAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Domain.Services.Payment.ResidencePaymentDomainServices;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.Payment.ResidencePaymentAppServices
{
    public class ResidencePaymentAppService : BaseAppService, IResidencePaymentAppService
    {
        private IMapper _mapper;
        private IResidencePaymentDomainService _residencePaymentDomainService;
        public ResidencePaymentAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper, IResidencePaymentDomainService residencePaymentDomainService) : base(repository)
        {
            _mapper = mapper;
            _residencePaymentDomainService = residencePaymentDomainService;
        }

        public async Task<Response> CreateResidencePayment(CreateResidencePaymentRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));

            var domainExceptionError = _residencePaymentDomainService.ValidateResidencePayment(request);
            if (domainExceptionError != null) return new Response { ValidationErrorMessage = domainExceptionError.ValidationErrorCode };

            var residencePayments = request.Residences.Select(x => new ResidencePayment
            {
                ResidenceId = x.ResidenceId,
                InitialPaymentDate = x.InitialPaymentDate.Value,
                PaymentNo = request.PaymentNo,
            });

            await _repository.AddRangeAsync(residencePayments);

            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(request.RequestUserInfo, Transactions.CreateResidencePayments);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };

        }

        public async Task<Response> DeleteResidencePayment(DeleteResidencePaymentRequest deleteResidencePaymentRequest)
        {
            ThrowIf.Argument.IsNull(deleteResidencePaymentRequest, nameof(deleteResidencePaymentRequest));
            ThrowIf.Argument.IsZeroOrNegative(deleteResidencePaymentRequest.Id, nameof(deleteResidencePaymentRequest.Id));

            var residencePayment = await _repository.GetSingleAsync<ResidencePayment>(x => x.Id == deleteResidencePaymentRequest.Id);

            if (residencePayment == null) return new Response { Success = false, ValidationErrorMessage = $"El registro con el Id {deleteResidencePaymentRequest.Id} que quiere eliminar no existe" };

            await _repository.RemoveAsync(residencePayment);
            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(deleteResidencePaymentRequest.RequestUserInfo, Transactions.DeleteResidencePayment);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<ResidencePaymentResponse> GetResidencePayments(int residenceId)
        {
            var residencePayments = await _repository.GetFilteredAsync<ResidencePayment>(x => x.ResidenceId == residenceId, asNoTracking: true);

            var residencePaymentsDto = _mapper.Map<List<ResidencePaymentDto>>(residencePayments);

            return new ResidencePaymentResponse { ResidencePayments = residencePaymentsDto };
        }
    }
}
