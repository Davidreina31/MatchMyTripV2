using MatchMyTrip.Application.features.user.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.queries.getUserDetailsBySub
{
    public class GetUserDetailsBySubQuery : IRequest<UserDTO>
    {
        public string Sub { get; set; }
    }
}
