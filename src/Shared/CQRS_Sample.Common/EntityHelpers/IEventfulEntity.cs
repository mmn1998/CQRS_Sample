using CQRS_Sample.Common.MediatRHelpers;
using MediatR;

namespace CQRS_Sample.Common.EntityHelpers;

public interface IEventfulEntity
{
    void AddEvent(INotification @event);

    void RemoveEvent(INotification @event);

    void ClearEvents();

    IReadOnlyCollection<INotification> GetEvents();
}