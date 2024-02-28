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

namespace MatchMyTrip.Application.features.user.commands.updateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repo;

        public UpdateUserCommandHandler(IMapper mapper, IRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<UserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UserCommandResponse();

            var user = new User()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                Description = request.Description,
                ProfilePicture = request.ProfilePicture,
                Role = request.Role
            };

            user = await _repo.UpdateAsync(user);
            response.User = _mapper.Map<UserDTO>(user);

            return response;
        }
    }
}
