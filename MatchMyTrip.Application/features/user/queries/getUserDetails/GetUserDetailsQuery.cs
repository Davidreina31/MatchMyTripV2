using MatchMyTrip.Application.features.user.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.queries.getUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserQueryDTO>
    {
        public Guid Id { get; set; }
    }
}
