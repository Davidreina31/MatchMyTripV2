using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.match_activity.commands.common;
using MatchMyTrip.Application.features.match_activity.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.commands.createMatch_ActivityCommand
{
    public class CreateMatch_ActivityCommandHandler : IRequestHandler<CreateMatch_ActivityCommand, Match_ActivityCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match_Activity> _repo;

        public CreateMatch_ActivityCommandHandler(IMapper mapper, IRepository<Match_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Match_ActivityCommandResponse> Handle(CreateMatch_ActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new Match_ActivityCommandResponse();

            var match_activity = new Match_Activity()
            {
                MatchId = request.MatchId,
                ActivityId = request.ActivityId
            };

            match_activity = await _repo.AddAsync(match_activity);
            response.Match_Activity = _mapper.Map<Match_ActivityDTO>(match_activity);

            return response;
        }
    }
}
