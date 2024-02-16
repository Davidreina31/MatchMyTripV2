using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.activity.queries.getActivities
{
    public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, List<ActivityDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Activity> _repo;

        public GetActivitiesQueryHandler(IMapper mapper, IRepository<Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<List<ActivityDTO>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {
            var activities = await _repo.GetAllAsync();
            return _mapper.Map<List<ActivityDTO>>(activities);
        }
    }
}
