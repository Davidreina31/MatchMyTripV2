using MatchMyTrip.Application.features.activity.commands.createActivityCommand;
using MatchMyTrip.Application.features.activity.commands.deleteActivityCommand;
using MatchMyTrip.Application.features.activity.commands.updateActivityCommand;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.activity.queries.getActivities;
using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.deleteJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey.queries.getJourneyDetails;
using MatchMyTrip.Application.features.journey.queries.getJournies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JourneyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<JourneyDTO>>> Get()
        {
            var dtos = await _mediator.Send(new GetJourneysQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JourneyDTO>> GetById(Guid id)
        {
            var dtos = await _mediator.Send(new GetJourneyDetailsQuery() { Id = id });
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateJourneyCommand>> Create([FromBody] CreateJourneyCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateJourneyCommand>> Update([FromBody] UpdateJourneyCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteJourneyCommand>> Delete([FromQuery] DeleteJourneyCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
    }
}
