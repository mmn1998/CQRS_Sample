using CQRS_Sample.Application.Events.SomeModels;
using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Application.Commands.Handlers.SomeModels;

public class SomeModelEventHandler : IEventHandler<CreateSomeModelEvent>
{
}
