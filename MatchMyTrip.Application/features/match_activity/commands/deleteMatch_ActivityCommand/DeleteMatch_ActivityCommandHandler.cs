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

namespace MatchMyTrip.Application.features.match_activity.commands.deleteMatch_ActivityCommand
{
    public class DeleteMatch_ActivityCommandHandler : IRequestHandler<DeleteMatch_ActivityCommand, Match_ActivityCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match_Activity> _repo;

        public DeleteMatch_ActivityCommandHandler(IMapper mapper, IRepository<Match_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Match_ActivityCommandResponse> Handle(DeleteMatch_ActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new Match_ActivityCommandResponse();
            var match_activity = await _repo.DeleteAsync(request.Id);

            response.Match_Activity = _mapper.Map<Match_ActivityDTO>(match_activity);

            return response;
        }
    }
}
