using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey_activity.dtos;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Profile
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public UserQueryDTO User { get; set; } = new UserQueryDTO();

        public List<JourneyDTO> Journeys { get; set; } = new List<JourneyDTO>();


        protected override async Task OnInitializedAsync()
        {
            if(Id == null || Id == "Id")
                Id = "DE1152A3-7DF4-4548-E134-08DC3452ABC2";
            User = await UserService.GetUserById(Guid.Parse(Id));

            Journeys = User.Journeys;
        }

    }
}
