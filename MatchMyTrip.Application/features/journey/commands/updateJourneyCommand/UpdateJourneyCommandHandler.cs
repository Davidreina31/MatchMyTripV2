using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.commands.common;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.commands.updateJourneyCommand
{
    public class UpdateJourneyCommandHandler : IRequestHandler<UpdateJourneyCommand, JourneyCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey> _repo;

        public UpdateJourneyCommandHandler(IMapper mapper, IRepository<Journey> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<JourneyCommandResponse> Handle(UpdateJourneyCommand request, CancellationToken cancellationToken)
        {
            var response = new JourneyCommandResponse();

            var journey = new Journey()
            {
                Id = request.Id,
                Destination = request.Destination,
                NbrOfDays = request.NbrOfDays,
                Seasons = request.Seasons,
                UserId = request.UserId
            };

            journey = await _repo.UpdateAsync(journey);
            response.Journey = _mapper.Map<JourneyDTO>(journey);

            return response;
        }
    }
}
