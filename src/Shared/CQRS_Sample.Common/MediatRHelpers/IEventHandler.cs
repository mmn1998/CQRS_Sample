using MediatR;

namespace CQRS_Sample.Common.MediatRHelpers;

public interface IEventHandler<in TNotification> : INotificationHandler<IEvent> where TNotification : IEvent
{
}
