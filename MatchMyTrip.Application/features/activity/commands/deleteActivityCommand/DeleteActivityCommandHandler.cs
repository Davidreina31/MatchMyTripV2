using AutoMapper;
using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.activity.commands.common;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.activity.commands.deleteActivityCommand
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, ActivityCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Activity> _repo;

        public DeleteActivityCommandHandler(IMapper mapper, IRepository<Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        async Task<ActivityCommandResponse> IRequestHandler<DeleteActivityCommand, ActivityCommandResponse>.Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new ActivityCommandResponse();
            var activity = await _repo.DeleteAsync(request.Id);

            response.Activity = _mapper.Map<ActivityDTO>(activity);

            return response;
        }
    }
}
