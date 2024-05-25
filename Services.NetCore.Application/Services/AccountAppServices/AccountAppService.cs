using AutoMapper;
using Azure.Core;
using Microsoft.Identity.Client;
using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Account;
using Services.NetCore.Domain.Aggregates.AccountAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.AccountAppServices
{
    public class AccountAppService : BaseAppService, IAccountAppService
    {
        private readonly IMapper _mapper;
        public AccountAppService(IGenericRepository<IGenericDataContext> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public async Task<Response> CreateOrUpdateAccountAsync(AccountRequest request)
        {
            ThrowIf.Argument.IsNull(request, nameof(request));
            ThrowIf.Argument.IsNull(request.Account, nameof(request.Account));
            TransactionInfo transactionInfo;

            var account = await _repository.GetSingleAsync<Account>(x => x.Id == request.Account.Id);
            if (account == null)
            {
                account = _mapper.Map<Account>(request.Account);
                transactionInfo = TransactionInfoFactory.CrearTransactionInfo(request.RequestUserInfo, Transactions.CreateAccount);

                await _repository.AddAsync(account);
            }
            else
            {
                account.FullName = request.Account.FullName;
                account.PhoneNumber = request.Account.PhoneNumber;
                account.Residence = request.Account.Residence;
                account.AccountType = request.Account.AccountType;
                account.Residential = request.Account.Residential;
                account.Block = request.Account.Block;
                account.HouseNumber = request.Account.HouseNumber;
                account.ResidentialId = request.Account.ResidentialId;
                account.AllowEmergy = request.Account.AllowEmergy;
                account.LockCode = request.Account.LockCode;
                account.UserId = request.Account.UserId;
                transactionInfo = TransactionInfoFactory.CrearTransactionInfo(request.RequestUserInfo, Transactions.UpdateAccount);
            }

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true, Message = "Account Created/Updated Successfully." };
        }

        public async Task<AccountResponse> GetAccountsAsync(string searchValue = null)
        {
            var accounts = await _repository.GetFilteredAsync<Account>(x =>
            string.IsNullOrEmpty(searchValue) ||
            x.FullName.Contains(searchValue) ||
            x.Email.Contains(searchValue) ||
            x.PhoneNumber.Contains(searchValue));

            var accountsDto = _mapper.Map<List<AccountDto>>(accounts);

            return new AccountResponse { Success = true, Accounts = accountsDto };
        }

        public async Task<Response> RemoveAccountAsync(DeleteAccountRequest deleteUserRequest)
        {
            ThrowIf.Argument.IsNull(deleteUserRequest, nameof(deleteUserRequest));
            ThrowIf.Argument.IsZeroOrNegative(deleteUserRequest.AccountId, nameof(deleteUserRequest.AccountId));

            var account = await _repository.GetSingleAsync<Account>(x => x.Id == deleteUserRequest.AccountId);

            if (account == null) return new Response { Success = false, Message = "Account not found." };

            var transactionInfo = TransactionInfoFactory.CrearTransactionInfo(deleteUserRequest.RequestUserInfo, Transactions.DeleteAccount);
            await _repository.RemoveAsync(account);
            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true, Message = "Account removed successfully." };
        }
    }
}
