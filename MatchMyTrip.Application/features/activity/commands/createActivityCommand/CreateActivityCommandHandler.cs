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

namespace MatchMyTrip.Application.features.activity.commands.createActivityCommand
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, ActivityCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Activity> _repo;

        public CreateActivityCommandHandler(IMapper mapper, IRepository<Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ActivityCommandResponse> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new ActivityCommandResponse();
            var validator = new CreateActivityCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (response.Success)
            {
                var activity = new Activity() { ActivityName = request.ActivityName };
                activity = await _repo.AddAsync(activity);
                response.Activity = _mapper.Map<ActivityDTO>(activity);
            }

            return response;
        }
    }
}
