using MatchMyTrip.Application.features.user.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.queries.getUserDetailsByEmail
{
    public class GetUserDetailsByEmailQuery : IRequest<UserDTO>
    {
        public string Email { get; set; }
    }
}
