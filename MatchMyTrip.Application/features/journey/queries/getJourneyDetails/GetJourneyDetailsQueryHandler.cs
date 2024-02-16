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

namespace MatchMyTrip.Application.features.journey.queries.getJourneyDetails
{
    public class GetJourneyDetailsQueryHandler : IRequestHandler<GetJourneyDetailsQuery, JourneyDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey> _repo;

        public GetJourneyDetailsQueryHandler(IMapper mapper, IRepository<Journey> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<JourneyDTO> Handle(GetJourneyDetailsQuery request, CancellationToken cancellationToken)
        {
            var journey = await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<JourneyDTO>(journey);
        }
    }
}
