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

namespace MatchMyTrip.Application.features.match.queries.getMatchDetails
{
    public class GetMatchDetailsQueryHandler : IRequestHandler<GetMatchDetailsQuery, MatchDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match> _repo;

        public GetMatchDetailsQueryHandler(IMapper mapper, IRepository<Match> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<MatchDTO> Handle(GetMatchDetailsQuery request, CancellationToken cancellationToken)
        {
            var match = await _repo.GetByIdAsync(request.Id);

            return _mapper.Map<MatchDTO>(match);    
        }
    }
}
