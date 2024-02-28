using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.queries.getUserDetails
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserQueryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repo;

        public GetUserDetailsQueryHandler(IMapper mapper, IRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<UserQueryDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<UserQueryDTO>(user);
        }
    }
}
