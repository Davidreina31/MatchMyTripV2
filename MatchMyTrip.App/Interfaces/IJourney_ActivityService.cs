using MatchMyTrip.Application.features.journey_activity.commands.createJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.dtos;

namespace MatchMyTrip.App.Interfaces
{
    public interface IJourney_ActivityService
    {
        Task<List<Journey_ActivityQueryDTO>> GetActivitiesByJourneyId(Guid id);
        Task DeleteJourneyActivity(DeleteJourney_ActivityCommand deleteJourney_ActivityCommand);    
        Task<Journey_ActivityDTO> AddActivityToJourney(CreateJourney_ActivityCommand createJourney_ActivityCommand);
    }
}
