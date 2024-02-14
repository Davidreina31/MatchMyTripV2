using System.ComponentModel.DataAnnotations.Schema;

namespace MatchMyTrip.Domain.entities
{
    public class Match_Activity
    {
        public Guid Id { get; set; }

        [ForeignKey("Match")]
        public Guid MatchId { get; set; }

        public Match Match { get; set; }

        [ForeignKey("Activity")]
        public Guid ActivityId { get; set; }

        public Activity Activity { get; set; }
    }
}