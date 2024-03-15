using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.user.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.queries.getUserDetailsByEmail
{
    public class GetUserDetailsByEmailQueryHandler : IRequestHandler<GetUserDetailsByEmailQuery, UserDTO>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public GetUserDetailsByEmailQueryHandler(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserDetailsByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserByEmail(request.Email);

            return _mapper.Map<UserDTO>(user);
        }
    }
}