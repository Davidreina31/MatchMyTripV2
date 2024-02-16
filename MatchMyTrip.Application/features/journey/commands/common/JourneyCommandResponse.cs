using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.commands.common
{
    public class JourneyCommandResponse : BaseResponse
    {
        public JourneyCommandResponse() : base()
        {
            
        }

        public JourneyDTO Journey { get; set; }
    }
}
