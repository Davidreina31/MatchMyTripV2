using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.journey_activity.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.queries.getSingleJourney_Activity
{
    public class GetSingleJourney_ActivityQueryHandler : IRequestHandler<GetSingleJourney_ActivityQuery, List<Journey_ActivityQueryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IJourney_ActivityRepository _repo;

        public GetSingleJourney_ActivityQueryHandler(IMapper mapper, IJourney_ActivityRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<Journey_ActivityQueryDTO>> Handle(GetSingleJourney_ActivityQuery request, CancellationToken cancellationToken)
        {
            var journey_activity = await _repo.GetAllByJourneyId(request.Id);

            return _mapper.Map<List<Journey_ActivityQueryDTO>>(journey_activity);
        }
    }
}
