using MatchMyTrip.Application.features.journey_activity.dto;
using MatchMyTrip.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.contracts
{
    public interface IJourney_ActivityRepository
    {
        Task<List<Journey_Activity>> GetAllByJourneyId(Guid id);
    }
}
