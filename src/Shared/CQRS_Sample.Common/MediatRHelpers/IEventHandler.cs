using MediatR;

namespace CQRS_Sample.Common.MediatRHelpers;

public interface IEventHandler : INotificationHandler<IEvent>
{
}
