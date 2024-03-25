using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.journey.commands.deleteJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey_activity.dtos;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class JourneyDetail
    {
        [Inject]
        public IJourney_ActivityService Journey_ActivityService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public JourneyDTO Journey { get; set; } = new JourneyDTO();

        public List<Journey_ActivityQueryDTO> Activities { get; set; } = new List<Journey_ActivityQueryDTO>();

        public DeleteJourneyCommand JourneyCommand { get; set; } = new DeleteJourneyCommand();

        [Inject]
        public IJourneyService JourneyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public UserDTO CurrentUser { get; set; } = new UserDTO();

        [Inject]
        public ISharedService SharedService { get; set; }

        public bool IsSameUserAsProfile { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            Journey = await JourneyService.GetById(Guid.Parse(Id));

            CurrentUser = await SharedService.GetCurrentUser();

            if (CurrentUser.Id == Journey.UserId)
            {
                IsSameUserAsProfile = true;
            }
            Activities = await Journey_ActivityService.GetActivitiesByJourneyId(Guid.Parse(Id));
        }

        protected async Task Delete(Guid id)
        {
            JourneyCommand.Id = id;

            await JourneyService.DeleteJourney(id);

            NavigationManager.NavigateTo("/Profile/" + Journey.UserId);
        }
    }
}
