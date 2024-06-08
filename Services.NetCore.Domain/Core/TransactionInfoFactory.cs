using Services.NetCore.Crosscutting.Core;

namespace Services.NetCore.Domain.Core
{
    public static class TransactionInfoFactory
    {
        public static TransactionInfo CreateTransactionInfo(UserInfoDto userInfoDTO, string transaccionId)
        {
            TransactionInfo transactionInfo = new TransactionInfo(userInfoDTO.CreatedBy, transaccionId);

            transactionInfo.GenerateTransactions = true;

            return transactionInfo;
        }
    }
}
