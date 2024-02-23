using MatchMyTrip.Application.features.user.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.queries.getUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDTO>
    {
        public Guid Id { get; set; }
    }
}
