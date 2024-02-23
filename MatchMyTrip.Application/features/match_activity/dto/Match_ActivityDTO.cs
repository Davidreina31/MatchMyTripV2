using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.dto
{
    public class Match_ActivityDTO
    {
        public Guid Id { get; set; }

        public Guid MatchId { get; set; }

        public Guid ActivityId { get; set; }
    }
}
