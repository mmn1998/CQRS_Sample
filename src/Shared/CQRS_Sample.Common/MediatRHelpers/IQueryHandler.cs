using MediatR;

namespace CQRS_Sample.Common.MediatRHelpers;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{

}