using MediatR;

namespace CQRS_Sample.Common.MediatRHelpers;

public interface IQuery<TResult> : IRequest<TResult>
{

}