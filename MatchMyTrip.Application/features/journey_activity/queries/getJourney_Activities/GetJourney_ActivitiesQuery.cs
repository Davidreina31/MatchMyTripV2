using MatchMyTrip.Application.features.journey_activity.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.queries.getJourney_Activities
{
    public class GetJourney_ActivitiesQuery : IRequest<List<Journey_ActivityDTO>>
    {
    }
}
