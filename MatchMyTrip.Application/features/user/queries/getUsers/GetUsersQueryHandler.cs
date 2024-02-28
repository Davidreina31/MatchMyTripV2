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

namespace MatchMyTrip.Application.features.user.queries.getUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repo;

        public GetUsersQueryHandler(IMapper mapper, IRepository<User> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<List<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repo.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}
