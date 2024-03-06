using MatchMyTrip.App.Interfaces;
using MatchMyTrip.App.services;
using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Add_journey
    {
        [Inject]
        public IJourneyService JourneyService { get; set; }

        public CreateJourneyCommand JourneyCommand { get; set; } = new CreateJourneyCommand();

        [Parameter]
        public string UserId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async Task HandleValidSubmit()
        {
            JourneyCommand.UserId = Guid.Parse(UserId);

            await JourneyService.AddJourney(JourneyCommand);

            NavigationManager.NavigateTo("/Profile/" + UserId);
        }
    }
}
