using MatchMyTrip.App.Interfaces;
using MatchMyTrip.App.services;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.search.commands.specificSearch;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class SpecificSearch
    {
        [Inject]
        public ISearchService SearchService { get; set; }
        public List<JourneyDTO> Journeys { get; set; } = new List<JourneyDTO>();
        public SpecificSearchCommand SearchByFilters { get; set; } = new SpecificSearchCommand();
        public FilterDTO Filter { get; set; } = new FilterDTO();
        public string ErrorMsg { get; set; }
        protected async Task HandleValidSubmit()
        {
            ErrorMsg = "";

            SearchByFilters.Filter = Filter;
            SearchByFilters.Filter.Destination = "Phuket";
            SearchByFilters.Filter.NbrOfDays = 3;
            SearchByFilters.Filter.Seasons = Domain.enums.Seasons.Winter;

            Journeys = await SearchService.GetMatchListByFilters(SearchByFilters);

            if (Journeys.Count == 0)
                ErrorMsg = "Aucun résultat disponible.";

        }
    }
}
