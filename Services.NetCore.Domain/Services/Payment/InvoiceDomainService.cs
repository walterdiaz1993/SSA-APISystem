using Services.NetCore.Crosscutting.Dtos.Invoice;
using Services.NetCore.Domain.Core;

namespace Services.NetCore.Domain.Services.Payment
{
    public class InvoiceDomainService : IInvoiceDomainService
    {
        public DomainExceptionError ValidateInvoice(InvoiceDto invoice)
        {
            if (string.IsNullOrWhiteSpace(invoice.InvoiceNo))
            {
                return new DomainExceptionError("InvoiceNo is required");
            }

            if (invoice.ResidenceId <= 0)
            {
                return new DomainExceptionError("ResidenceId is required");
            }

            if (string.IsNullOrWhiteSpace(invoice.DepositNo))
            {
                return new DomainExceptionError("DepositNo is required");
            }

            if (string.IsNullOrWhiteSpace(invoice.Comments))
            {
                return new DomainExceptionError("Comments are required");
            }

            if (invoice.Total <= 0)
            {
                return new DomainExceptionError("Total is required and must be greater than 0.");
            }

            foreach (var detail in invoice.InvoiceDetail)
            {
                var detailError = ValidateInvoiceDetail(detail);
                if (detailError != null)
                {
                    return detailError;
                }
            }

            return null;
        }

        private DomainExceptionError ValidateInvoiceDetail(InvoiceDetailDto invoiceDetail)
        {
            if (string.IsNullOrWhiteSpace(invoiceDetail.PaymentTypeNo) || invoiceDetail.PaymentTypeNo.Length > 30)
            {
                return new DomainExceptionError("PaymentTypeNo is required and must be at most 30 characters long.");
            }

            if (invoiceDetail.Quantity <= 0)
            {
                return new DomainExceptionError("Quantity is required and must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(invoiceDetail.Description) || invoiceDetail.Description.Length > 200)
            {
                return new DomainExceptionError("Description is required and must be at most 200 characters long.");
            }

            if (invoiceDetail.Cost <= 0)
            {
                return new DomainExceptionError("Cost is required and must be greater than 0.");
            }

            if (invoiceDetail.Amount <= 0)
            {
                return new DomainExceptionError("Amount is required and must be greater than 0.");
            }

            return null;
        }
    }
}
