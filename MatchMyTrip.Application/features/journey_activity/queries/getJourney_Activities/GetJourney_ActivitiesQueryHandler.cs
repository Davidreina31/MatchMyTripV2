using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.journey_activity.dtos;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.queries.getJourney_Activities
{
    public class GetJourney_ActivitiesQueryHandler : IRequestHandler<GetJourney_ActivitiesQuery, List<Journey_ActivityDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey_Activity> _repo;

        public GetJourney_ActivitiesQueryHandler(IMapper mapper, IRepository<Journey_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<Journey_ActivityDTO>> Handle(GetJourney_ActivitiesQuery request, CancellationToken cancellationToken)
        {
            var journey_activities = await _repo.GetAllAsync();

            return _mapper.Map<List<Journey_ActivityDTO>>(journey_activities);
        }
    }
}
