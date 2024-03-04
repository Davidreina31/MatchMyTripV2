using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.dto
{
    public class JourneyDTO
    {
        public Guid Id { get; set; }

        public string Destination { get; set; }

        public int NbrOfDays { get; set; }

        public Seasons Seasons { get; set; }

        public Guid UserId { get; set; }

        public UserDTO User { get; set; }
    }
}
