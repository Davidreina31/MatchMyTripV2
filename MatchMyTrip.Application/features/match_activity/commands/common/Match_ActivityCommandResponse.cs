using MatchMyTrip.Application.features.match_activity.dto;
using MatchMyTrip.Application.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.commands.common
{
    public class Match_ActivityCommandResponse : BaseResponse
    {
        public Match_ActivityCommandResponse() : base()
        {
            
        }

        public Match_ActivityDTO Match_Activity { get; set; }
    }
}
