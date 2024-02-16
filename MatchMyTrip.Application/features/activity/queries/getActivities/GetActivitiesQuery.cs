using MatchMyTrip.Application.features.activity.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.activity.queries.getActivities
{
    public class GetActivitiesQuery : IRequest<List<ActivityDTO>>
    {
    }
}
