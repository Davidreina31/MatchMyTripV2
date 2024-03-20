using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.user.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.queries.getUserDetailsBySub
{
    public class GetUserDetailsBySubQueryHandler : IRequestHandler<GetUserDetailsBySubQuery, UserDTO>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public GetUserDetailsBySubQueryHandler(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserDetailsBySubQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUserBySub(request.Sub);

            return _mapper.Map<UserDTO>(user);
        }
    }
}