using MatchMyTrip.Application.features.activity.commands.createActivityCommand;
using MatchMyTrip.Application.features.activity.dto;

namespace MatchMyTrip.App.Interfaces
{
    public interface IActivityService
    {
        Task<List<ActivityDTO>> GetActivities();
        Task<ActivityDTO> AddActivity(CreateActivityCommand activity);
    }
}
