using MatchMyTrip.Application.features.journey_activity.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.queries.getSingleJourney_Activity
{
    public class GetSingleJourney_ActivityQuery : IRequest<List<Journey_ActivityQueryDTO>>
    {
        public Guid Id { get; set; }
    }
}
