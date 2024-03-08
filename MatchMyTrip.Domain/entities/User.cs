using MatchMyTrip.Domain.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatchMyTrip.Domain.entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public Roles Role { get; set; }

        public List<Match> Matches { get; set; }

        public List<Journey> Journeys { get; set; }

        [NotMapped]
        public byte[] ImageContent { get; set; }
        public string? ImageName { get; set; }
    }
}
