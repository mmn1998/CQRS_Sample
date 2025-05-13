using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Persistence.Query.Models.SomeModels;

public class GetAllSomeModelsQuery : IQuery<IEnumerable<GetSomeModelQueryResult>>
{
}