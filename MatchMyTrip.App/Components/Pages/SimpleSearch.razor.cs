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
        public string ErrorMsg { get; set; }

        protected async Task HandleValidSubmit()
        {
            ErrorMsg = "";
            Users = await SearchService.GetMatchListByKeyWord(SearchByKeyWord);
            if (Users.Count == 0)
                ErrorMsg = "Aucun résultat disponible.";
        }
    }
}
