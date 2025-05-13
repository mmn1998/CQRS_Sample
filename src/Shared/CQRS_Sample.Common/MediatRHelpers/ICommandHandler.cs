using MediatR;

namespace CQRS_Sample.Common.MediatRHelpers;

public interface ICommandHandler<TCommand, T> : IRequestHandler<TCommand, T> where TCommand : ICommand<T>
{

}