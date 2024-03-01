using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class SimpleSearch
    {
        [Inject]
        public ISearchService SearchService { get; set; }

        public List<UserQueryDTO> Users { get; set; } = new List<UserQueryDTO>();

        protected override async Task OnInitializedAsync()
        {
            SearchByKeyWordCommand searchByKeyWordCommand = new SearchByKeyWordCommand();
            Users = await SearchService.GetMatchListByKeyWord(searchByKeyWordCommand);
        }
    }
}
