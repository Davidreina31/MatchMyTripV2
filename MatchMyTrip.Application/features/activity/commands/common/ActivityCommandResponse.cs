using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.activity.commands.common
{
    public class ActivityCommandResponse : BaseResponse
    {
        public ActivityCommandResponse() : base()
        {

        }

        public ActivityDTO Activity { get; set; }
    }
}
