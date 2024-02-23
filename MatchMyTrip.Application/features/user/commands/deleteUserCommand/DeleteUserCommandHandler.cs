using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.user.common;
using MatchMyTrip.Application.features.user.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.commands.deleteUserCommand
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repo;

        public DeleteUserCommandHandler(IMapper mapper, IRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<UserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UserCommandResponse();

            var user = await _repo.DeleteAsync(request.Id);

            response.User = _mapper.Map<UserDTO>(user);

            return response;
        }
    }
}
