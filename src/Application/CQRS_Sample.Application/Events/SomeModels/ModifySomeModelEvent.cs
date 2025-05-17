using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Application.Events.SomeModels;

public record ModifySomeModelEvent(long id, string name) : IEvent;
