using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.match.commands.common;
using MatchMyTrip.Application.features.match.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.commands.createMatchCommand
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, MatchCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Match> _repo;

        public CreateMatchCommandHandler(IMapper mapper, IRepository<Match> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<MatchCommandResponse> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            var response = new MatchCommandResponse();

            var match = new Match()
            {
                Destination = request.Destination,
                NbrOfDays = request.NbrOfDays,
                Seasons = request.Seasons,
                MatchScore = 3, //TODO
                Favorite = request.Favorite,
                UserId = request.UserId,
                JourneyId = request.JourneyId
            };

            match = await _repo.AddAsync(match);
            response.Match = _mapper.Map<MatchDTO>(match);

            return response;
        }
    }
}
