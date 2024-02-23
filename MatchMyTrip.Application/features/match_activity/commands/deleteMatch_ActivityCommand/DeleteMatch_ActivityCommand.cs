using MatchMyTrip.Application.features.match_activity.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.commands.deleteMatch_ActivityCommand
{
    public class DeleteMatch_ActivityCommand : IRequest<Match_ActivityCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
