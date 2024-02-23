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

namespace MatchMyTrip.Application.features.match_activity.queries.getSingleMatch_Activity
{
    public class GetSingleMatch_ActivityQueryHandler : IRequestHandler<GetSingleMatch_ActivityQuery, Match_ActivityDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match_Activity> _repo;

        public GetSingleMatch_ActivityQueryHandler(IMapper mapper, IRepository<Match_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Match_ActivityDTO> Handle(GetSingleMatch_ActivityQuery request, CancellationToken cancellationToken)
        {
            var match_activity = await _repo.GetByIdAsync(request.Id);

            return _mapper.Map<Match_ActivityDTO>(match_activity);
        }
    }
}
