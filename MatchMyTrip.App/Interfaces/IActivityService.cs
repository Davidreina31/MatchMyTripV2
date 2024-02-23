using MatchMyTrip.Application.features.activity.dto;

namespace MatchMyTrip.App.Interfaces
{
    public interface IActivityService
    {
        Task<List<ActivityDTO>> GetActivities();
    }
}
