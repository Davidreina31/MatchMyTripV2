using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.user.dto;

namespace MatchMyTrip.App.Interfaces
{
    public interface IJourneyService
    {
        Task<List<JourneyDTO>> GetUsers();
        Task<JourneyDTO> GetUserById(Guid id);
    }
}
