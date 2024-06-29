namespace Services.NetCore.Domain.Core
{
    public static class Transactions
    {
        public const string Insert = nameof(Insert);
        public const string Update = nameof(Update);
        public const string CreateLogException = nameof(CreateLogException);
        public const string Added = nameof(Added);
        public const string UpdateUser = nameof(UpdateUser);
        public const string CreateUser = nameof(CreateUser);
        public const string DeleteUser = nameof(DeleteUser);
        public const string CreateAccount = nameof(CreateAccount);
        public const string DeleteAccount = nameof(DeleteAccount);
        public const string UpdateAccount = nameof(UpdateAccount);
        public const string DisableMassiveAccounts = nameof(DisableMassiveAccounts);
        public const string EnableMassiveAccounts = nameof(EnableMassiveAccounts);
        public const string CreatePermission = nameof(CreatePermission);
        public const string UpdatePermission = nameof(UpdatePermission);
        public const string CreateRole = nameof(CreateRole);
        public const string UpdateRole = nameof(UpdateRole);
        public const string DeletePermission = nameof(DeletePermission);
        public const string DeleteRole = nameof(DeleteRole);
        public const string ProvideAccess = nameof(ProvideAccess);
        public const string DeleteAccessPermissionToUser = nameof(DeleteAccessPermissionToUser);
        public const string RemoveAccessRoleToUser = nameof(RemoveAccessRoleToUser);
        public const string UpdateResidential = nameof(UpdateResidential);
        public const string CreateResidential = nameof(CreateResidential);
        public const string DeleteResidential = nameof(DeleteResidential);
        public const string UpdateResidence = nameof(UpdateResidence);
        public const string CreateResidence = nameof(CreateResidence);
        public const string DeleteResidence = nameof(DeleteResidence);
        public const string DeletePaymentType = nameof(DeletePaymentType);
        public const string CreatePaymentType = nameof(CreatePaymentType);
        public const string UpdatePaymentType = nameof(UpdatePaymentType);
        public const string CreateInvoice = nameof(CreateInvoice);
        public const string UpdateInvoice = nameof(UpdateInvoice);
        public const string DeleteInvoice = nameof(DeleteInvoice);
        public const string CreateResidencePayments = nameof(CreateResidencePayments);
        public const string DeleteResidencePayment = nameof(DeleteResidencePayment);
        public const string UpdatePassword = nameof(UpdatePassword);
    }
}
