using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.commands.createActivityCommand;
using MatchMyTrip.Application.features.activity.dto;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Add_activity
    {
        [Inject]
        public IActivityService ActivityService { get; set; }

        public CreateActivityCommand CreateActivity { get; set; } = new CreateActivityCommand();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task HandleValidSubmit()
        {
            await ActivityService.AddActivity(CreateActivity);
            NavigationManager.NavigateTo("/Activities");
        }
    }
}
