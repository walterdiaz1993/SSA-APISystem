using AutoMapper;
using Services.NetCore.Application.Core;
using Services.NetCore.Application.Services.CommonAppServices;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Crosscutting.Dtos.Invoice;
using Services.NetCore.Crosscutting.Dtos.Residence;
using Services.NetCore.Domain.Aggregates.InvoiceAgg;
using Services.NetCore.Domain.Aggregates.InvoiceDetailAgg;
using Services.NetCore.Domain.Aggregates.ResidenceAgg;
using Services.NetCore.Domain.Aggregates.ResidentialAgg;
using Services.NetCore.Domain.Core;
using Services.NetCore.Domain.Services.Payment;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.InvoiceAppServices
{
    public class InvoiceAppService : BaseAppService, IInvoiceAppService
    {
        private readonly IInvoiceDomainService _invoiceDomainService;
        private readonly IMapper _mapper;
        private readonly ICommonAppService _commonAppService;
        public InvoiceAppService(IGenericRepository<IGenericDataContext> repository, IInvoiceDomainService invoiceDomainService, IMapper mapper, ICommonAppService commonAppService) : base(repository)
        {
            _invoiceDomainService = invoiceDomainService;
            _mapper = mapper;
            _commonAppService = commonAppService;
        }

        public async Task<InvoiceResponse> CreateOrUpdateInvoiceAsync(InvoiceRequest invoiceRequest)
        {
            ThrowIf.Argument.IsNull(invoiceRequest, nameof(invoiceRequest));
            ThrowIf.Argument.IsNull(invoiceRequest.Invoice, nameof(invoiceRequest.Invoice));

            var domainValidationError = _invoiceDomainService.ValidateInvoice(invoiceRequest.Invoice);

            if (domainValidationError != null) return new InvoiceResponse { ValidationErrorMessage = domainValidationError.Message };
            TransactionInfo transactionInfo;
            var invoice = await _repository.GetSingleAsync<Invoice>(x => x.Id == invoiceRequest.Invoice.Id);
            if (invoice == null)
            {
                invoice = _mapper.Map<Invoice>(invoiceRequest.Invoice);
                invoice.InvoiceNo = await _commonAppService.GenerateCorrelative(CorrelativeTypes.IN);
                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(invoiceRequest.RequestUserInfo, Transactions.CreateInvoice);

                await _repository.AddAsync(invoice);
            }
            else
            {
                invoice.AccountId = invoiceRequest.Invoice.AccountId;
                invoice.DepositNo = invoiceRequest.Invoice.DepositNo;
                invoice.Comments = invoiceRequest.Invoice.DepositNo;
                invoice.Total = invoiceRequest.Invoice.Total;
                invoice.InvoiceDate = invoiceRequest.Invoice.InvoiceDate;
                invoice.ResidenceId = invoiceRequest.Invoice.ResidenceId;
                invoice.Customer = invoiceRequest.Invoice.Customer;
                invoice.Block = invoiceRequest.Invoice.Block;
                invoice.HouseNumber = invoiceRequest.Invoice.HouseNumber;
                invoice.Total = invoiceRequest.Invoice.InvoiceDetail.Sum(x => x.Amount);
                invoice.InvoiceDetail = invoiceRequest.Invoice.InvoiceDetail.Select(x =>
                new InvoiceDetail
                {
                    Id = x.Id,
                    PaymentTypeNo = x.PaymentTypeNo,
                    Quantity = x.Quantity,
                    Cost = x.Cost,
                    Description = x.Description,
                    Amount = x.Amount,
                    InvoiceId = x.InvoiceId,
                }).ToList();

                transactionInfo = TransactionInfoFactory.CreateTransactionInfo(invoiceRequest.RequestUserInfo, Transactions.UpdateInvoice);
            }

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new InvoiceResponse { Success = true };
        }

        public async Task<Response> DeleteAsync(DeleteInvoiceRequest invoiceRequest)
        {
            ThrowIf.Argument.IsNull(invoiceRequest, nameof(invoiceRequest));
            ThrowIf.Argument.IsZeroOrNegative(invoiceRequest.Id, nameof(invoiceRequest.Id));

            var invoice = await _repository.GetSingleAsync<Invoice>(r => r.Id == invoiceRequest.Id, new List<string> { "InvoiceDetail" });
            if (invoice == null) return new Response { Success = false, Message = Setting.residentialDoesntExist };
            await _repository.RemoveRange(invoice.InvoiceDetail);
            await _repository.RemoveAsync(invoice);

            TransactionInfo transactionInfo = TransactionInfoFactory.CreateTransactionInfo(invoiceRequest.RequestUserInfo, Transactions.DeleteInvoice);

            await _repository.UnitOfWork.CommitAsync(transactionInfo);

            return new Response { Success = true };
        }

        public async Task<InvoiceResponse> GetInvoices(string searchValue = null)
        {
            var invoicesDto = new List<InvoiceDto>();
            IEnumerable<Invoice> invoices = null;
            if (!string.IsNullOrEmpty(searchValue))
            {
                if (int.TryParse(searchValue, out int residenceId))
                {
                    invoices = await _repository.GetFilteredAsync<Invoice>(r => r.ResidenceId == residenceId, new List<string> { "InvoiceDetail" });

                    if (!invoices.Any())
                    {
                        invoices = await _repository.GetFilteredAsync<Invoice>(r => r.DepositNo.Contains(searchValue)
                                                                                    || r.InvoiceNo.Contains(searchValue), new List<string> { "InvoiceDetail" });
                    }
                }
            }
            else
            {
                invoices = await _repository.GetAllIncludeAsync<Invoice>(new List<string> { "InvoiceDetail" });
            }

            if (!invoices.Any())
            {
                invoices = await _repository.GetFilteredAsync<Invoice>(r => r.DepositNo.Contains(searchValue)
                                                                            || r.InvoiceNo.Contains(searchValue), new List<string> { "InvoiceDetail" });
            }

            invoicesDto = _mapper.Map<List<InvoiceDto>>(invoices);
            return new InvoiceResponse { Invoices = invoicesDto, Success = true };

        }
    }
}
