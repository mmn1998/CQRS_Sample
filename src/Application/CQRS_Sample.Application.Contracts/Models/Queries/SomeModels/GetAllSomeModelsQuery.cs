using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Application.Contracts.Models.Queries.SomeModels;

public class GetAllSomeModelsQuery : IQuery<IEnumerable<GetSomeModelQueryResult>>
{
}