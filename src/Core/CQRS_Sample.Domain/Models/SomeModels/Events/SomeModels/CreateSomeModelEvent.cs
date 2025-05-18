using MediatR;

namespace CQRS_Sample.Application.Events.SomeModels;

public record CreateSomeModelEvent(long id, string name) : INotification;