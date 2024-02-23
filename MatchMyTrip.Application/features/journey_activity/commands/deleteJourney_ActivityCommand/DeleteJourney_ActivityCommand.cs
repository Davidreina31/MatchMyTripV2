using MatchMyTrip.Application.features.journey_activity.commands.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand
{
    public class DeleteJourney_ActivityCommand : IRequest<Journey_ActivityCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
