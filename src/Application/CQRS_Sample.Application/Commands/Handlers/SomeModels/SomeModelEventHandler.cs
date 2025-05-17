using CQRS_Sample.Application.Events.SomeModels;
using CQRS_Sample.Domain.Models.SomeModels;
using CQRS_Sample.Persistence.Query.Repositories.SomeModels;
using MediatR;

namespace CQRS_Sample.Application.Commands.Handlers.SomeModels;

public class SomeModelEventHandler : INotificationHandler<CreateSomeModelEvent>,
    INotificationHandler<ModifySomeModelEvent>,
    INotificationHandler<DeleteSomeModelEvent>
{
    private readonly ISomeModelQueryRepository _queryRepository;

    public SomeModelEventHandler(ISomeModelQueryRepository queryRepository)
    {
        _queryRepository = queryRepository;
    }

    public Task Handle(CreateSomeModelEvent notification, CancellationToken cancellationToken)
    {
        var arg = new CreateSomeModelArg { Id = notification.id, Name = notification.name };
        _queryRepository.SyncData_Add(arg);
        return Task.CompletedTask;
    }
    public Task Handle(ModifySomeModelEvent notification, CancellationToken cancellationToken)
    {
        var arg = new ModifySomeModelArg { Id = notification.id, Name = notification.name };
        _queryRepository.SyncData_Edit(arg);
        return Task.CompletedTask;
    }

    public Task Handle(DeleteSomeModelEvent notification, CancellationToken cancellationToken)
    {
        _queryRepository.SyncData_Delete(notification.id);
        return Task.CompletedTask;
    }
}
