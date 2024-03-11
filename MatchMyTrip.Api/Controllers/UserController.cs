using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.deleteJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey.queries.getJourneyDetails;
using MatchMyTrip.Application.features.journey.queries.getJournies;
using MatchMyTrip.Application.features.user.commands.createUserCommand;
using MatchMyTrip.Application.features.user.commands.deleteUserCommand;
using MatchMyTrip.Application.features.user.commands.updateUserCommand;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Application.features.user.queries.getUserDetails;
using MatchMyTrip.Application.features.user.queries.getUsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IMediator mediator, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var dtos = await _mediator.Send(new GetUsersQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(Guid id)
        {
            var dtos = await _mediator.Send(new GetUserDetailsQuery() { Id = id });
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserCommand>> Create([FromBody] CreateUserCommand command)
        {
            string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{command.ImageName}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(command.ImageContent, 0, command.ImageContent.Length);
            fileStream.Close();

            command.ImageName = $"https://{currentUrl}/uploads/{command.ImageName}";

            var dto = await _mediator.Send(command);
            return Ok(dto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var currentUser = await _mediator.Send(new GetUserDetailsQuery() { Id = command.Id });

            if (currentUser.ImageContent != command.ImageContent || currentUser.ImageName != command.ImageName)
            {
                string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
                var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{command.ImageName}";
                var fileStream = System.IO.File.Create(path);
                fileStream.Write(command.ImageContent, 0, command.ImageContent.Length);
                fileStream.Close();

                command.ImageName = $"https://{currentUrl}/uploads/{command.ImageName}";
            }

            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteUserCommand>> Delete([FromQuery] DeleteUserCommand command)
        {
            var dto = await _mediator.Send(command);
            return Ok(dto);
        }
    }
}
