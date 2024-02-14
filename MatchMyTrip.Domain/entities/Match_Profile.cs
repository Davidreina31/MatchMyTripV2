using System.ComponentModel.DataAnnotations.Schema;

namespace MatchMyTrip.Domain.entities
{
    public class Match_Profile
    {
        public Guid Id { get; set; }

        [ForeignKey("Match")]
        public Guid MatchId { get; set; }

        public Match Match { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }

        public Profile Profile { get; set; }
    }
}