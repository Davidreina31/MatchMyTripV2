using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace MatchMyTrip.Domain.entities
{
    public class Profile
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Description { get; set; }

        public string ProfilePicture { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public List<Match> Matches { get; set; }

        public List<Journey> Journeys { get; set; }

        public List<Profile_Filter> Profile_Filters { get; set; }

        public List<Match_Profile> Match_Profiles { get; set; }
    }
}