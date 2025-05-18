using MediatR;

namespace CQRS_Sample.Application.Events.SomeModels;

public record DeleteSomeModelEvent(long id) : INotification;
