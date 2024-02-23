using MatchMyTrip.Application.features.match_activity.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.match_activity.queries.getMatch_Activities
{
    public class GetMatch_ActivitiesQuery : IRequest<List<Match_ActivityDTO>>
    {
    }
}
