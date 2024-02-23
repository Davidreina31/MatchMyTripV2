using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.journey_activity.commands.common;
using MatchMyTrip.Application.features.journey_activity.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand
{
    public class DeleteJourney_ActivityCommandHandler : IRequestHandler<DeleteJourney_ActivityCommand, Journey_ActivityCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey_Activity> _repo;

        public DeleteJourney_ActivityCommandHandler(IMapper mapper, IRepository<Journey_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<Journey_ActivityCommandResponse> Handle(DeleteJourney_ActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new Journey_ActivityCommandResponse();
            var journey_activity = await _repo.DeleteAsync(request.Id);

            response.Journey_Activity = _mapper.Map<Journey_ActivityDTO>(journey_activity);

            return response;
            
        }
    }
}
