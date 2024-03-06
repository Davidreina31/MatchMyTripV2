using MatchMyTrip.Application.features.activity.commands.createActivityCommand;
using MatchMyTrip.Application.features.activity.commands.deleteActivityCommand;
using MatchMyTrip.Application.features.activity.commands.updateActivityCommand;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.activity.queries.getActivities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActivityDTO>>> Get()
        {
            var dtos = await _mediator.Send(new GetActivitiesQuery());
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<ActivityDTO>> Create([FromBody] CreateActivityCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateActivityCommand>> Update([FromBody] UpdateActivityCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteActivityCommand>> Delete([FromQuery] DeleteActivityCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
    }
}
