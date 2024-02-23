using MatchMyTrip.Application.features.journey_activity.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.commands.createJourney_ActivityCommand
{
    public class CreateJourney_ActivityCommand : IRequest<Journey_ActivityCommandResponse>
    {
        public Guid JourneyId { get; set; }

        public Guid ActivityId { get; set; }
    }
}
