using MediatR;

namespace CQRS_Sample.Common.EntityHelpers;

public class BaseEntity : IEventfulEntity
{
    private List<INotification>? _events;
    public void AddEvent(INotification @event)
    {
        _events = _events ?? new List<INotification>();
        _events.Add(@event);
    }

    public void ClearEvents()
    {
        _events.Clear();
    }

    public IReadOnlyCollection<INotification> GetEvents()
    {
        return _events?.AsReadOnly();
    }

    public void RemoveEvent(INotification @event)
    {
        _events?.Remove(@event);
    }
}
