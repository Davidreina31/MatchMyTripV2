using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.queries.getJournies
{
    public class GetJourneysQueryHandler : IRequestHandler<GetJourneysQuery, List<JourneyDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey> _repo;

        public GetJourneysQueryHandler(IMapper mapper, IRepository<Journey> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<List<JourneyDTO>> Handle(GetJourneysQuery request, CancellationToken cancellationToken)
        {
            var journeys = await _repo.GetAllAsync();
            return _mapper.Map<List<JourneyDTO>>(journeys);
        }
    }
}
