using MatchMyTrip.Application.features.journey_activity.dto;
using MatchMyTrip.Application.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.commands.common
{
    public class Journey_ActivityCommandResponse : BaseResponse
    {
        public Journey_ActivityCommandResponse() : base()
        {
            
        }

        public Journey_ActivityDTO Journey_Activity { get; set; }
    }
}
