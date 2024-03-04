using MatchMyTrip.App.Interfaces;
using MatchMyTrip.App.services;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.search.commands.specificSearch;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class SpecificSearch
    {
        [Inject]
        public ISearchService SearchService { get; set; }
        public List<JourneyDTO> Journeys { get; set; } = new List<JourneyDTO>();
        public SpecificSearchCommand SearchByFilters { get; set; } = new SpecificSearchCommand();
        public string ErrorMsg { get; set; }

        protected async Task HandleValidSubmit()
        {
            ErrorMsg = "";

            Journeys = await SearchService.GetMatchListByFilters(SearchByFilters);

            if (Journeys == null || Journeys.Count == 0)
                ErrorMsg = "Aucun résultat disponible.";

            foreach (var item in Journeys)
            {
                item.MatchScore = GetMatchScore(SearchByFilters, item);
            }
        }

        private int GetMatchScore(SpecificSearchCommand command, JourneyDTO journey)
        {
            int matchScore = 1;

            if (command.Filter.NbrOfDays == journey.NbrOfDays)
                matchScore += 1;
            if (command.Filter.Seasons == journey.Seasons)
                matchScore += 1;

            return matchScore;
        }
    }
}
