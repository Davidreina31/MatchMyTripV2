using MatchMyTrip.Application.features.match_activity.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.queries.getSingleMatch_Activity
{
    public class GetSingleMatch_ActivityQuery : IRequest<Match_ActivityDTO>
    {
        public Guid Id { get; set; }
    }
}
