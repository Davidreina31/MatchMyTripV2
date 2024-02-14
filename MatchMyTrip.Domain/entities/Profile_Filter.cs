using System.ComponentModel.DataAnnotations.Schema;

namespace MatchMyTrip.Domain.entities
{
    public class Profile_Filter
    {
        public Guid Id { get; set; }

        [ForeignKey("Profile")]
        public Guid ProfileId { get; set; }

        public Profile Profile { get; set; }

        [ForeignKey("Filter")]
        public Guid FilterId { get; set; }

        public Filter Filter { get; set; }
    }
}