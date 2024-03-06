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
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand>
    {
        private readonly IRepository<Activity> _repo;

        public DeleteActivityCommandHandler(IRepository<Activity> repo)
        {
            _repo = repo;
        }

        public async Task Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
        }
    }
}
