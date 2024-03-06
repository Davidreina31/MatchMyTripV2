using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.journey_activity.commands.common;
using MatchMyTrip.Application.features.journey_activity.dtos;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand
{
    public class DeleteJourney_ActivityCommandHandler : IRequestHandler<DeleteJourney_ActivityCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Journey_Activity> _repo;

        public DeleteJourney_ActivityCommandHandler(IMapper mapper, IRepository<Journey_Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task Handle(DeleteJourney_ActivityCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
        }
    }
}
