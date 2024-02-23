using MatchMyTrip.Application.features.match_activity.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.commands.createMatch_ActivityCommand
{
    public class CreateMatch_ActivityCommand : IRequest<Match_ActivityCommandResponse>
    {
        public Guid MatchId { get; set; }

        public Guid ActivityId { get; set; }
    }
}
