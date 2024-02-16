using AutoMapper;
using FluentValidation;
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

namespace MatchMyTrip.Application.features.activity.commands.updateActivityCommand
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, ActivityCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Activity> _repo;

        public UpdateActivityCommandHandler(IMapper mapper, IRepository<Activity> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ActivityCommandResponse> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new ActivityCommandResponse();
            var validator = new UpdateActivityCommandValidator();
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
                var activity = new Activity() { 
                    Id = request.Id,
                    ActivityName = request.ActivityName };
                activity = await _repo.UpdateAsync(activity);
                response.Activity = _mapper.Map<ActivityDTO>(activity);
            }

            return response;
        }
    }
}
