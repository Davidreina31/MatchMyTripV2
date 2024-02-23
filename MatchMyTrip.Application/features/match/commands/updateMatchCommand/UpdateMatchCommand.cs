using MatchMyTrip.Application.features.match.commands.common;
using MatchMyTrip.Domain.enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.commands.updateMatchCommand
{
    public class UpdateMatchCommand : IRequest<MatchCommandResponse>
    {
        public Guid Id { get; set; }

        public string Destination { get; set; }

        public int NbrOfDays { get; set; }

        public Seasons Seasons { get; set; }

        public int MatchScore { get; set; }

        public bool Favorite { get; set; }

        public Guid UserId { get; set; }

        public Guid JourneyId { get; set; }
    }
}
