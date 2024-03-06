using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey_activity.commands.createJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.dtos;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Add_activity_to_journey
    {
        [Inject]
        public IJourney_ActivityService Journey_ActivityService { get; set; }

        [Parameter]
        public string JourneyId { get; set; }

        [Inject]
        public IActivityService ActivityService { get; set; }

        public List<ActivityDTO> Activities { get; set; } = new List<ActivityDTO>();

        public List<Journey_ActivityQueryDTO> ActivitiesForJourney { get; set; } = new List<Journey_ActivityQueryDTO>();
        
        public DeleteJourney_ActivityCommand DeleteJourney_ActivityCommand = new DeleteJourney_ActivityCommand();
        
        public CreateJourney_ActivityCommand CreateJourney_ActivityCommand { get; set; } = new CreateJourney_ActivityCommand();

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Activities = await ActivityService.GetActivities();

            ActivitiesForJourney = await Journey_ActivityService.GetActivitiesByJourneyId(Guid.Parse(JourneyId));

            foreach (var item in Activities)
            {
                if (ActivitiesForJourney.Where(x => x.ActivityId == item.Id).Any())
                {
                    item.IsSelected = true;
                }
            }
        }

        protected async Task HandleValidSubmit()
        {
            CreateJourney_ActivityCommand.JourneyId = Guid.Parse(JourneyId);

            foreach (var item in ActivitiesForJourney)
            {
                DeleteJourney_ActivityCommand.Id = item.Id;

                await Journey_ActivityService.DeleteJourneyActivity(DeleteJourney_ActivityCommand);
            }

            foreach (var item in Activities.Where(x => x.IsSelected))
            {
                CreateJourney_ActivityCommand.ActivityId = item.Id;

                await Journey_ActivityService.AddActivityToJourney(CreateJourney_ActivityCommand);
            }

            NavigationManager.NavigateTo("/journey/" + JourneyId);
        }
    }
}
