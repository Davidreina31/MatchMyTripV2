using MatchMyTrip.Application.features.match.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match.queries.getMatchDetails
{
    public class GetMatchDetailsQuery : IRequest<MatchDTO>
    {
        public Guid Id { get; set; }
    }
}
