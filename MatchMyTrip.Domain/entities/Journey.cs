using MatchMyTrip.Domain.enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatchMyTrip.Domain.entities
{
    public class Journey
    {
        public Guid Id { get; set; }

        public string Destination { get; set; }

        public int NbrOfDays { get; set; }

        public Seasons Seasons { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }

        public Profile Profile { get; set; }

        public List<Journey_Activity> Journey_Activities { get; set; }
    }
}