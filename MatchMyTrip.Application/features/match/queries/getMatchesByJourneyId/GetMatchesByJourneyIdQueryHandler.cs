using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.match.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.queries.getMatchesByJourneyId
{
    public class GetMatchesByJourneyIdQueryHandler : IRequestHandler<GetMatchesByJourneyIdQuery, List<MatchDTO>>
    {
        private readonly IMatchRepository _repo;
        private readonly IMapper _mapper;

        public GetMatchesByJourneyIdQueryHandler(IMatchRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<MatchDTO>> Handle(GetMatchesByJourneyIdQuery request, CancellationToken cancellationToken)
        {
            var matches = await _repo.GetAllByJourneyId(request.JourneyId);

            return _mapper.Map<List<MatchDTO>>(matches);
        }
    }
}
