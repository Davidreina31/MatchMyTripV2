using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.journey.commands.common;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.commands.deleteJourneyCommand
{
    public class DeleteJourneyCommandHandler : IRequestHandler<DeleteJourneyCommand, JourneyCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey> _repo;

        public DeleteJourneyCommandHandler(IMapper mapper, IRepository<Journey> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<JourneyCommandResponse> Handle(DeleteJourneyCommand request, CancellationToken cancellationToken)
        {
            var response = new JourneyCommandResponse();
            var journey = await _repo.DeleteAsync(request.Id);

            response.Journey = _mapper.Map<JourneyDTO>(journey);

            return response;
        }
    }
}
