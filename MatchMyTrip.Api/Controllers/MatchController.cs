using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.deleteJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey.queries.getJourneyDetails;
using MatchMyTrip.Application.features.journey.queries.getJournies;
using MatchMyTrip.Application.features.match.commands.createMatchCommand;
using MatchMyTrip.Application.features.match.commands.deleteMatchCommand;
using MatchMyTrip.Application.features.match.commands.updateMatchCommand;
using MatchMyTrip.Application.features.match.dto;
using MatchMyTrip.Application.features.match.queries.getMatchDetails;
using MatchMyTrip.Application.features.match.queries.getMatches;
using MatchMyTrip.Application.features.match.queries.getMatchesByJourneyId;
using MatchMyTrip.Application.features.match.queries.getMatchesByUserId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<MatchDTO>>> Get()
        {
            var dtos = await _mediator.Send(new GetMatchesQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDTO>> GetById(Guid id)
        {
            var dtos = await _mediator.Send(new GetMatchDetailsQuery() { Id = id });
            return Ok(dtos);
        }

        [HttpGet("ByUserId/{id}")]
        public async Task<ActionResult<List<MatchDTO>>> GetAllByUserId(Guid id)
        {
            var dtos = await _mediator.Send(new GetMatchesByUserIdQuery() { UserId = id });
            return Ok(dtos);
        }

        [HttpGet("ByJourneyId/{id}")]
        public async Task<ActionResult<List<MatchDTO>>> GetAllByJourneyId(Guid id)
        {
            var dtos = await _mediator.Send(new GetMatchesByJourneyIdQuery() { JourneyId = id });
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateMatchCommand>> Create([FromBody] CreateMatchCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateMatchCommand>> Update([FromBody] UpdateMatchCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteMatchCommand>> Delete([FromQuery] DeleteMatchCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
    }
}
