using MatchMyTrip.Application.features.journey_activity.dtos;

namespace MatchMyTrip.App.Interfaces
{
    public interface IJourney_ActivityService
    {
        Task<List<Journey_ActivityQueryDTO>> GetActivitiesByJourneyId(Guid id);
    }
}
