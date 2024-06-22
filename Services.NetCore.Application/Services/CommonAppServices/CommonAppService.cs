using Services.NetCore.Application.Core;
using Services.NetCore.Crosscutting.Core;
using Services.NetCore.Domain.Aggregates.CorrelativeAgg;
using Services.NetCore.Infraestructure.Core;
using Services.NetCore.Infraestructure.Data.UnitOfWork;

namespace Services.NetCore.Application.Services.CommonAppServices
{
    public class CommonAppService : BaseAppService, ICommonAppService
    {
        public CommonAppService(IGenericRepository<IGenericDataContext> repository) : base(repository)
        {
        }

        public async Task<string> GenerateCorrelative(string correlativeType)
        {
            Correlative correlative = await _repository.GetSingleAsync<Correlative>(x => x.Type == correlativeType);

            if (correlative == null)
                ThrowIf.Argument.IsNull(correlative, CommonsDictionary.correlativeDoesntExist);

            return correlative.GetNextCorrelative();
        }
    }
}
