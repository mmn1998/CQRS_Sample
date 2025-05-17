using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Application.Contracts.Models.Commands.SomeModels;

public class DeleteSomeModelCommand : ICommand<long>
{
    public long Id { get; set; }
}
