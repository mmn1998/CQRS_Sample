using MediatR;

namespace CQRS_Sample.Common.MediatRHelpers;

public interface ICommand<T> : IRequest<T>
{
}
