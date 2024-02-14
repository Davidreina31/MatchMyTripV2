using System.ComponentModel.DataAnnotations.Schema;

namespace MatchMyTrip.Domain.entities
{
    public class Journey_Activity
    {
        public Guid Id { get; set; }

        [ForeignKey("Journey")]
        public Guid JourneyId { get; set; }

        public Journey Journey { get; set; }

        [ForeignKey("Activity")]
        public Guid ActivityId { get; set; }

        public Activity Activity { get; set; }
    }
}