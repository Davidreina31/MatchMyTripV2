
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Edit_journey
    {
        [Parameter]
        public string JourneyId { get; set; }

        [Inject]
        public IJourneyService JourneyService { get; set; }

        public JourneyDTO Journey { get; set; } = new JourneyDTO();

        public UpdateJourneyCommand JourneyCommand { get; set; } = new UpdateJourneyCommand();

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Journey = await JourneyService.GetById(Guid.Parse(JourneyId));
        }

        protected async Task HandleValidSubmit()
        {
            JourneyCommand.Id = Guid.Parse(JourneyId);
            JourneyCommand.Destination = Journey.Destination;
            JourneyCommand.NbrOfDays = Journey.NbrOfDays;
            JourneyCommand.Seasons = Journey.Seasons;

            await JourneyService.UpdateJourney(JourneyCommand);

            NavigationManager.NavigateTo("/Profile/" + Journey.UserId);
        }
    }
}
