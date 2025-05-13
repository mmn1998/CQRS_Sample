using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Common.EntityHelpers;

public class BaseEntity : IEventfulEntity
{
    private List<IEvent>? _events;
    public void AddEvent(IEvent @event)
    {
        _events = _events ?? new List<IEvent>();
        _events.Add(@event);
    }

    public void ClearEvents()
    {
        _events?.Clear();
    }

    public IReadOnlyCollection<IEvent> GetEvents()
    {
        _events = _events ?? new List<IEvent>();
        return _events.AsReadOnly();
    }

    public void RemoveEvent(IEvent @event)
    {
        _events?.Remove(@event);
    }
}
