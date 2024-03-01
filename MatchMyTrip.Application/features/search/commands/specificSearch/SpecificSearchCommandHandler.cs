using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.search.commands.specificSearch
{
    public class SpecificSearchCommandHandler : IRequestHandler<SpecificSearchCommand, List<JourneyDTO>>
    {
        private readonly ISearchRepository _repo;
        private readonly IMapper _mapper;

        public SpecificSearchCommandHandler(ISearchRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<JourneyDTO>> Handle(SpecificSearchCommand request, CancellationToken cancellationToken)
        {
            var journeys = await _repo.GetMatchListByFilters(_mapper.Map<Filter>(request.Filter));

            return _mapper.Map<List<JourneyDTO>>(journeys);
        }
    }
}
