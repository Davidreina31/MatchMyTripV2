using MatchMyTrip.Application.features.journey.commands.common;
using MatchMyTrip.Domain.enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.commands.createJourneyCommand
{
    public class CreateJourneyCommand : IRequest<JourneyCommandResponse>
    {
        public string Destination { get; set; }

        public int NbrOfDays { get; set; }

        public Seasons Seasons { get; set; }

        public Guid UserId { get; set; }
    }
}
