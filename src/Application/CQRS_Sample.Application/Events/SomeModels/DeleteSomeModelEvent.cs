using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Application.Events.SomeModels;

public record DeleteSomeModelEvent(long id) : IEvent;
