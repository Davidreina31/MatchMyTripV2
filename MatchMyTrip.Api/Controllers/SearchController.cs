using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.search.commands.specificSearch;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("searchByKeyWord")]
        public async Task<ActionResult<List<UserQueryDTO>>> GetByKeyWords([FromBody] SearchByKeyWordCommand searchByKeyWordCommand)
        {
            var dto = await _mediator.Send(searchByKeyWordCommand);
            return Ok(dto);
        }

        [HttpPost("searchByFilter")]
        public async Task<ActionResult<SpecificSearchCommand>> GetByFilters([FromBody] SpecificSearchCommand specificSearchCommand)
        {
            var dto = await _mediator.Send(specificSearchCommand);
            return Ok(dto);
        }
    }
}
