using MatchMyTrip.Application.features.journey.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.commands.deleteJourneyCommand
{
    public class DeleteJourneyCommand : IRequest<JourneyCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
