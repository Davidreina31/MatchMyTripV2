using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.match.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.queries.getMatches
{
    public class GetMatchesQueryHandler : IRequestHandler<GetMatchesQuery, List<MatchDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match> _repo;

        public GetMatchesQueryHandler(IMapper mapper, IRepository<Match> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<MatchDTO>> Handle(GetMatchesQuery request, CancellationToken cancellationToken)
        {
            var matches = await _repo.GetAllAsync();

            return _mapper.Map<List<MatchDTO>>(matches);
        }
    }
}
