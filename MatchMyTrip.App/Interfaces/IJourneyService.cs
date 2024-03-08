using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;

namespace MatchMyTrip.App.Interfaces
{
    public interface IJourneyService
    {
        Task<List<JourneyDTO>> GetAll();
        Task<JourneyDTO> GetById(Guid id);
        Task<JourneyDTO> AddJourney(CreateJourneyCommand createJourneyCommand);
        Task UpdateJourney(UpdateJourneyCommand updateJourneyCommand);
        Task DeleteJourney(Guid id);
    }
}
