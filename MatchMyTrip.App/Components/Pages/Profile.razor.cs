using MatchMyTrip.App.Interfaces;
using MatchMyTrip.App.services;
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
            User = await UserService.GetUserById(Guid.Parse(Id));

            Journeys = User.Journeys;
        }

    }
}
