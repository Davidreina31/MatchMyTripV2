using MatchMyTrip.Domain.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Domain.entities
{
    public class Match
    {
        public Guid Id { get; set; }

        public string Destination { get; set; }

        public int NbrOfDays { get; set; }

        public Seasons Seasons { get; set; }

        public int MatchScore { get; set; }

        public bool Favorite { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }

        public Profile Profile { get; set; }

        [ForeignKey("Journey")]
        public Guid JourneyId { get; set; }

        public Journey Journey { get; set; }

        public List<Match_Activity> Match_Activities { get; set; }
    }
}
