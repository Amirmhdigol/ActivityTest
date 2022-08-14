using ActivityTest.Application.ActivityType.Add;
using ActivityTest.Application.ActivityType.Delete;
using ActivityTest.Application.ActivityType.Edit;
using ActivityTest.Application.Common;
using ActivityTest.Query.ActivityTypeQuery.DTOs;
using ActivityTest.Query.ActivityTypeQuery.GetById;
using ActivityTest.Query.ActivityTypeQuery.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActivityTest.Api.ApiHelper;

namespace ActivityTest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityTypeController : Utilities
{
    private readonly IMediator _mediator;
    public ActivityTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ApiResult<ActivityTypeDTO>> GetActivityTypeById(int id)
    {
        var model = new GetActivityTypeByIdQuery(id);
        var result = await _mediator.Send(model);

        return QueryResult(result);
    }
    
    [HttpGet]
    public async Task<ApiResult<List<ActivityTypeDTO>>> GetActivityTypeList()
    {
        var model = new GetActivityTypeListQuery();
        var result = await _mediator.Send(model);

        return QueryResult(result);
    }

    [HttpPost]
    public async Task<ApiResult> CreateActivityType(AddActivityTypeCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }
        
    [HttpPut]
    public async Task<ApiResult> EditActivityType(EditActivityTypeCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }
    
    [HttpPut("Delete")]
    public async Task<ApiResult> DeleteActivityType(DeleteActivityTypeCommand command)
    {
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }
}