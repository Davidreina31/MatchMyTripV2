using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.activity.commands.common;
using MatchMyTrip.Application.features.activity.commands.createActivityCommand;
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

namespace MatchMyTrip.Application.features.journey.commands.createJourneyCommand
{
    public class CreateJourneyCommandHandler : IRequestHandler<CreateJourneyCommand, JourneyCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey> _repo;

        public CreateJourneyCommandHandler(IMapper mapper, IRepository<Journey> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<JourneyCommandResponse> Handle(CreateJourneyCommand request, CancellationToken cancellationToken)
        {
            var response = new JourneyCommandResponse();

            var journey = new Journey() 
            {
                Destination = request.Destination,
                NbrOfDays = request.NbrOfDays,
                Seasons = request.Seasons,
                UserId = request.UserId
            };
            journey = await _repo.AddAsync(journey);
            response.Journey = _mapper.Map<JourneyDTO>(journey);

            return response;
        }
    }
}
