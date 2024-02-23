using MatchMyTrip.Application.features.match.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.commands.deleteMatchCommand
{
    public class DeleteMatchCommand : IRequest<MatchCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
