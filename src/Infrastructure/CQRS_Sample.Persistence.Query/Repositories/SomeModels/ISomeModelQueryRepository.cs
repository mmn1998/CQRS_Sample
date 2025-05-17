using CQRS_Sample.Application.Contracts.Models.Queries.SomeModels;
using CQRS_Sample.Domain.Models.SomeModels;
using SIMA.Framework.Core.Repository;

namespace CQRS_Sample.Persistence.Query.Repositories.SomeModels;

public interface ISomeModelQueryRepository : IQueryRepository
{
    Task SyncData_Add(CreateSomeModelArg arg);
    Task SyncData_Edit(ModifySomeModelArg arg);
    Task SyncData_Delete(long id);
    Task<IEnumerable<GetSomeModelQueryResult>> GetAll(GetAllSomeModelsQuery request);
    Task<GetSomeModelQueryResult> GetById(GetSomeModelQuery request);
}