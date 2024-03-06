using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Activity
    {
        [Inject]
        public IActivityService ActivityService { get; set; }

        public List<ActivityDTO> Activities { get; set; } = new List<ActivityDTO>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Activities = await ActivityService.GetActivities();
        }

        protected void NavigateToForm()
        {
            NavigationManager.NavigateTo("/add-activity");
        }
    }
}
