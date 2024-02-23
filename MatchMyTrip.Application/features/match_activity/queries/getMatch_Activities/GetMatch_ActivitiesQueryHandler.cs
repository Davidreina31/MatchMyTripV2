using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.match_activity.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.queries.getMatch_Activities
{
    public class GetMatch_ActivitiesQueryHandler : IRequestHandler<GetMatch_ActivitiesQuery, List<Match_ActivityDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match_Activity> _repo;

        public GetMatch_ActivitiesQueryHandler(IMapper mapper, IRepository<Match_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<Match_ActivityDTO>> Handle(GetMatch_ActivitiesQuery request, CancellationToken cancellationToken)
        {
            var match_activities = await _repo.GetAllAsync();

            return _mapper.Map<List<Match_ActivityDTO>>(match_activities);
        }
    }
}
