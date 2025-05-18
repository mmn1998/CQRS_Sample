using MediatR;

namespace CQRS_Sample.Application.Events.SomeModels;

public record ModifySomeModelEvent(long id, string name) : INotification;
