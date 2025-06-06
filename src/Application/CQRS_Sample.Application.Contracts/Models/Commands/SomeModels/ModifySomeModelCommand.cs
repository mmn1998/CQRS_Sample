﻿using CQRS_Sample.Common.MediatRHelpers;

namespace CQRS_Sample.Application.Contracts.Models.Commands.SomeModels;

public class ModifySomeModelCommand : ICommand<long>
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}