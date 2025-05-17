using CQRS_Sample.Application.Contracts.Models.Queries.SomeModels;
using CQRS_Sample.Domain.Models.SomeModels;
using CQRS_Sample.Persistence.Query.Extensions;
using Microsoft.Extensions.Configuration;

namespace CQRS_Sample.Persistence.Query.Repositories.SomeModels;

public class SomeModelQueryRepository : ISomeModelQueryRepository
{
    private readonly string _connectionString;
    public SomeModelQueryRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString();
    }
    public Task<IEnumerable<GetSomeModelQueryResult>> GetAll(GetAllSomeModelsQuery request)
    {
        throw new NotImplementedException();
    }

    public Task<GetSomeModelQueryResult> GetById(GetSomeModelQuery request)
    {
        throw new NotImplementedException();
    }

    public Task SyncData(SomeModel entity, bool isAdded = false, bool isEdited = false, bool isDeleted = false)
    {
        throw new NotImplementedException();
    }
}
