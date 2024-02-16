using MatchMyTrip.Application.features.activity.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.activity.commands.updateActivityCommand
{
    public class UpdateActivityCommand : IRequest<ActivityCommandResponse>
    {
        public string ActivityName { get; set; }
    }
}
