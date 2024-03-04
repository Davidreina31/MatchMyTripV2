using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class SimpleSearch
    {
        [Inject]
        public ISearchService SearchService { get; set; }
        public List<UserQueryDTO> Users { get; set; } = new List<UserQueryDTO>();
        public SearchByKeyWordCommand SearchByKeyWord { get; set; } = new SearchByKeyWordCommand();

        protected async Task HandleValidSubmit()
        {
            Users = await SearchService.GetMatchListByKeyWord(SearchByKeyWord);
        }
    }
}
