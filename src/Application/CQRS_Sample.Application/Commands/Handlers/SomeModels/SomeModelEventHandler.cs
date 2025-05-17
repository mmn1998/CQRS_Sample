using CQRS_Sample.Application.Events.SomeModels;
using MediatR;

namespace CQRS_Sample.Application.Commands.Handlers.SomeModels;

public class SomeModelEventHandler : INotificationHandler<CreateSomeModelEvent>,
    INotificationHandler<ModifySomeModelEvent>,
    INotificationHandler<DeleteSomeModelEvent>
{
    public SomeModelEventHandler()
    {
        
    }
    public Task Handle(ModifySomeModelEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(CreateSomeModelEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(DeleteSomeModelEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
