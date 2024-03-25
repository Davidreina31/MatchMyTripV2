using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.commands.deleteActivityCommand;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.user.dtos;
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

        [Inject]
        public ISharedService SharedService { get; set; }

        public UserDTO CurrentUser { get; set; } = new UserDTO();


        protected override async Task OnInitializedAsync()
        {
            CurrentUser = await SharedService.GetCurrentUser();
            Activities = await ActivityService.GetActivities();
        }

        protected async Task Delete(Guid id)
        {
            DeleteActivityCommand deleteActivityCommand = new DeleteActivityCommand();
            deleteActivityCommand.Id = id;
            await ActivityService.DeleteActivity(deleteActivityCommand);

            Activities = await ActivityService.GetActivities();
        }
       
    }
}
