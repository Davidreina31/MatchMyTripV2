using MatchMyTrip.Application.features.match.dto;
using MatchMyTrip.Application.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.commands.common
{
    public class MatchCommandResponse : BaseResponse
    {
        public MatchCommandResponse() : base()
        {
            
        }

        public MatchDTO Match { get; set; }
    }
}
