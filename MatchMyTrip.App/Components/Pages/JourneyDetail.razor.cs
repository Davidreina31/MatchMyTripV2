using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.journey_activity.dto;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class JourneyDetail
    {
        [Inject]
        public IJourney_ActivityService Journey_ActivityService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<Journey_ActivityQueryDTO> Activities { get; set; } = new List<Journey_ActivityQueryDTO>();


        protected override async Task OnInitializedAsync()
        {
            Activities = await Journey_ActivityService.GetActivitiesByJourneyId(Guid.Parse(Id));
        }
    }
}
