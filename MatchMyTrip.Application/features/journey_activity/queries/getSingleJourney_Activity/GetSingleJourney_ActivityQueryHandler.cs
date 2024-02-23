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
    public class GetSingleJourney_ActivityQueryHandler : IRequestHandler<GetSingleJourney_ActivityQuery, Journey_ActivityDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey_Activity> _repo;

        public GetSingleJourney_ActivityQueryHandler(IMapper mapper, IRepository<Journey_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Journey_ActivityDTO> Handle(GetSingleJourney_ActivityQuery request, CancellationToken cancellationToken)
        {
            var journey_activity = await _repo.GetByIdAsync(request.Id);

            return _mapper.Map<Journey_ActivityDTO>(journey_activity);
        }
    }
}
