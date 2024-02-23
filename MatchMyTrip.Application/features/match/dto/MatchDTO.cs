using MatchMyTrip.Domain.entities;
using MatchMyTrip.Domain.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.dto
{
    public class MatchDTO
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
