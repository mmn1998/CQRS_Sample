using CQRS_Sample.Application.Contracts.Models.Queries.SomeModels;
using CQRS_Sample.Common.MediatRHelpers;
using CQRS_Sample.Persistence.Query.Repositories.SomeModels;

namespace CQRS_Sample.Application.Queries.Handlers.SomeModels;

public class SomeModelQueryHandler : IQueryHandler<GetSomeModelQuery, GetSomeModelQueryResult>,
    IQueryHandler<GetAllSomeModelsQuery, IEnumerable<GetSomeModelQueryResult>>
{
    private readonly ISomeModelQueryRepository _repository;

    public SomeModelQueryHandler(ISomeModelQueryRepository repository)
    {
        _repository = repository;
    }
    public async Task<GetSomeModelQueryResult> Handle(GetSomeModelQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetById(request);
    }

    public async Task<IEnumerable<GetSomeModelQueryResult>> Handle(GetAllSomeModelsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAll(request);
    }
}
