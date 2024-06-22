namespace Services.NetCore.Application.Services.CommonAppServices
{
    public interface ICommonAppService
    {
        Task<string> GenerateCorrelative(string correlativeType);
    }
}
