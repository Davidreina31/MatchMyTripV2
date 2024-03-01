using MatchMyTrip.Application.features.activity.commands.createActivityCommand;
using MatchMyTrip.Application.features.activity.commands.deleteActivityCommand;
using MatchMyTrip.Application.features.activity.commands.updateActivityCommand;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.activity.queries.getActivities;
using MatchMyTrip.Application.features.journey_activity.commands.createJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.dtos;
using MatchMyTrip.Application.features.journey_activity.queries.getJourney_Activities;
using MatchMyTrip.Application.features.journey_activity.queries.getSingleJourney_Activity;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Application.features.user.queries.getUserDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Journey_ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Journey_ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Journey_ActivityDTO>>> Get()
        {
            var dtos = await _mediator.Send(new GetJourney_ActivitiesQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Journey_ActivityQueryDTO>>> GetById(Guid id)
        {
            var dtos = await _mediator.Send(new GetSingleJourney_ActivityQuery() { Id = id });
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateJourney_ActivityCommand>> Create([FromBody] CreateJourney_ActivityCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }


        [HttpDelete]
        public async Task<ActionResult<DeleteJourney_ActivityCommand>> Delete([FromQuery] DeleteJourney_ActivityCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
    }
}
