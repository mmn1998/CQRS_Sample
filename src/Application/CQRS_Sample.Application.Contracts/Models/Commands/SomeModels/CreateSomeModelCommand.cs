using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Application.Contracts.Models.Commands.SomeModels;

public class CreateSomeModelCommand : ICommand<long>
{
    public string Name { get; set; } = string.Empty;
}