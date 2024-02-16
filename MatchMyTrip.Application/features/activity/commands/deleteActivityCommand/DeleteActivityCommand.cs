using MatchMyTrip.Application.features.activity.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.activity.commands.deleteActivityCommand
{
    public class DeleteActivityCommand : IRequest<ActivityCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
