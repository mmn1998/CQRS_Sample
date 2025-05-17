using CQRS_Sample.Application.Contracts.Models.Commands.SomeModels;
using CQRS_Sample.Application.Events.SomeModels;
using CQRS_Sample.Common.MediatRHelpers;
using CQRS_Sample.Domain.Models.SomeModels;
using CQRS_Sample.Persistence.Command.Repositories.SomeModels;
using Sima.Framework.Core.Repository;

namespace CQRS_Sample.Application.Commands.Handlers.SomeModels;

public class SomeModelCommandHandler : ICommandHandler<CreateSomeModelCommand, long>,
    ICommandHandler<ModifySomeModelCommand, long>,
    ICommandHandler<DeleteSomeModelCommand, long>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISomeModelCommandRepository _repository;

    public SomeModelCommandHandler(IUnitOfWork unitOfWork, ISomeModelCommandRepository repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    public async Task<long> Handle(CreateSomeModelCommand request, CancellationToken cancellationToken)
    {
        var id = request.Id;
        var arg = new CreateSomeModelArg { Id = id, Name = request.Name };
        var entity = SomeModel.Create(arg);
        var @event = new CreateSomeModelEvent(id, request.Name);
        entity.AddEvent(@event);
        await _repository.Add(entity);
        await _unitOfWork.SaveChangesAsync();
        return id;
    }

    public async Task<long> Handle(ModifySomeModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id);
        var arg = new ModifySomeModelArg { Name = request.Name };
        var @event = new ModifySomeModelEvent(entity.Id, request.Name);
        entity.AddEvent(@event);
        entity.Modify(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<long> Handle(DeleteSomeModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(request.Id);
        _repository.Remove(entity);
        var @event = new DeleteSomeModelEvent(entity.Id);
        entity.AddEvent(@event);
        await _unitOfWork.SaveChangesAsync();
        return entity.Id;
    }
}
