using AutoMapper;
using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.PaymentType;
using Services.NetCore.Domain.Aggregates.PaymentTypeAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.Payment.PaymentTypeAppServices
{
    public class PaymentTypeAppService : BaseAppService, IPaymentTypeAppService
    {
        private readonly IMapper _mapper;

        public PaymentTypeAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public async Task<Response> CreateOrUpdatePaymentTypeAsync(PaymentTypeRequest paymentTypeRequest)
        {
            ThrowIf.Argument.IsNull(paymentTypeRequest, nameof(paymentTypeRequest));
            ThrowIf.Argument.IsNull(paymentTypeRequest.PaymentType, nameof(paymentTypeRequest.PaymentType));

            var paymentTypeExistence = await _repository.GetSingleAsync<PaymentType>(r => r.Id == paymentTypeRequest.PaymentType.Id);
            TransactionInfo transactionInfo;

            if (paymentTypeExistence != null)
            {
                paymentTypeExistence.Name = paymentTypeRequest.PaymentType.Name;
                paymentTypeExistence.Description = paymentTypeRequest.PaymentType.Description;
                paymentTypeExistence.Cost = paymentTypeRequest.PaymentType.Cost;
                paymentTypeExistence.PaymentInterval = paymentTypeRequest.PaymentType.PaymentInterval;

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(paymentTypeRequest.RequestUserInfo, Transactions.UpdatePaymentType);
            }
            else
            {
                var newPaymentType = _mapper.Map<PaymentType>(paymentTypeRequest.PaymentType);

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(paymentTypeRequest.RequestUserInfo, Transactions.CreatePaymentType);
                await _repository.AddAsync(newPaymentType);
            }

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<Response> DeleTePaymentTypeAsync(DeletePaymentTypeRequest deletePaymentTypeRequest)
        {
            ThrowIf.Argument.IsNull(deletePaymentTypeRequest, nameof(deletePaymentTypeRequest));
            ThrowIf.Argument.IsZeroOrNegative(deletePaymentTypeRequest.Id, nameof(deletePaymentTypeRequest.Id));

            var paymentType = await _repository.GetSingleAsync<PaymentType>(r => r.Id == deletePaymentTypeRequest.Id);
            if (paymentType == null) return new Response { Success = false, Message = Setting.paymentTypeDoesntExist };
            await _repository.RemoveAsync(paymentType);

            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(deletePaymentTypeRequest.RequestUserInfo, Transactions.DeletePaymentType);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<PaymentTypeResponse> GetPaymentTypesAsync(string searchValue = null)
        {
            IEnumerable<PaymentType> paymentTypes;

            if (!string.IsNullOrEmpty(searchValue))
            {
                paymentTypes = await _repository.GetFilteredAsync<PaymentType>(r => r.Name.Contains(searchValue) || r.Description.Contains(searchValue));
            }
            else
            {
                paymentTypes = await _repository.GetAllAsync<PaymentType>();
            }

            var paymentTypesDtos = _mapper.Map<List<PaymentTypeDto>>(paymentTypes);

            return new PaymentTypeResponse { Success = true, PaymentTypes = paymentTypesDtos };
        }
    }
}
