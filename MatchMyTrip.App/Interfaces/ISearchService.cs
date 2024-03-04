using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.search.commands.specificSearch;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;

namespace MatchMyTrip.App.Interfaces
{
    public interface ISearchService
    {
        Task<List<UserQueryDTO>> GetMatchListByKeyWord(SearchByKeyWordCommand searchByKeyWordCommand);
        Task<List<JourneyDTO>> GetMatchListByFilters(SpecificSearchCommand specificSearchCommand);
    }
}
