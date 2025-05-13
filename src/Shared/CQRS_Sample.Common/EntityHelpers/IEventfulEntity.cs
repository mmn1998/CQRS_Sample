using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Common.EntityHelpers;

public interface IEventfulEntity
{
    void AddEvent(IEvent @event);

    void RemoveEvent(IEvent @event);

    void ClearEvents();

    IReadOnlyCollection<IEvent>? GetEvents();
}