using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.user.common;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.commands.createUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repo;
        public CreateUserCommandHandler(IMapper mapper, IRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<UserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UserCommandResponse();

            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Description = request.Description,
                Role = 0,
                ImageContent = request?.ImageContent,
                ImageName = request?.ImageName
            };

            await _repo.AddAsync(user);
            response.User = _mapper.Map<UserDTO>(user);

            return response;
        }
    }
}
