using CQRS_Sample.Application.Contracts.Models.Commands.SomeModels;
using CQRS_Sample.Application.Contracts.Models.Queries.SomeModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Sample.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SomeModelsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SomeModelsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<object> Get()
    {
        var query = new GetAllSomeModelsQuery();
        return await _mediator.Send(query);
    }
    [HttpGet("{id}")]
    public async Task<object> Get([FromRoute] long id)
    {
        var query = new GetSomeModelQuery { Id = id };
        return await _mediator.Send(query);
    }
    [HttpDelete("{id}")]
    public async Task<object> Delete([FromRoute] long id)
    {
        var command = new DeleteSomeModelCommand { Id = id };
        return await _mediator.Send(command);
    }
    [HttpPost]
    public async Task<object> Post([FromBody] CreateSomeModelCommand command)
    {
        return await _mediator.Send(command);
    }
    [HttpPut]
    public async Task<object> Put([FromBody] ModifySomeModelCommand command)
    {
        return await _mediator.Send(command);
    }
}
