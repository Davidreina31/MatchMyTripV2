using MatchMyTrip.Application.features.user.dto;
using MatchMyTrip.Application.responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.common
{
    public class UserCommandResponse : BaseResponse
    {
        public UserCommandResponse() : base()
        {
            
        }

        public UserDTO User { get; set; }
    }
}
