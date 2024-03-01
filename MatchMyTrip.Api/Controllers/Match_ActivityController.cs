using MatchMyTrip.Application.features.journey_activity.commands.createJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.dtos;
using MatchMyTrip.Application.features.journey_activity.queries.getJourney_Activities;
using MatchMyTrip.Application.features.journey_activity.queries.getSingleJourney_Activity;
using MatchMyTrip.Application.features.match_activity.commands.createMatch_ActivityCommand;
using MatchMyTrip.Application.features.match_activity.commands.deleteMatch_ActivityCommand;
using MatchMyTrip.Application.features.match_activity.dto;
using MatchMyTrip.Application.features.match_activity.queries.getMatch_Activities;
using MatchMyTrip.Application.features.match_activity.queries.getSingleMatch_Activity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Match_ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public Match_ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Match_ActivityDTO>>> Get()
        {
            var dtos = await _mediator.Send(new GetMatch_ActivitiesQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match_ActivityDTO>> GetById(Guid id)
        {
            var dtos = await _mediator.Send(new GetSingleMatch_ActivityQuery() { Id = id });
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateMatch_ActivityCommand>> Create([FromBody] CreateMatch_ActivityCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }


        [HttpDelete]
        public async Task<ActionResult<DeleteMatch_ActivityCommand>> Delete([FromQuery] DeleteMatch_ActivityCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
    }
}
