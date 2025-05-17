using CQRS_Sample.Application.Contracts.Models.Queries.SomeModels;
using CQRS_Sample.Domain.Models.SomeModels;
using SIMA.Framework.Core.Repository;

namespace CQRS_Sample.Persistence.Query.Repositories.SomeModels;

public interface ISomeModelQueryRepository : IQueryRepository
{
    Task SyncData(SomeModel entity);
    Task<IEnumerable<GetSomeModelQueryResult>> GetAll(GetAllSomeModelsQuery request);
    Task<GetSomeModelQueryResult> GetById(GetSomeModelQuery request);
}