
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.App.services;
using MatchMyTrip.Application.features.user.commands.updateUserCommand;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Edit_profile
    {
        [Parameter]
        public string UserId { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        public UserQueryDTO Profile { get; set; } = new UserQueryDTO();

        public UpdateUserCommand UserCommand { get; set; } = new UpdateUserCommand();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Profile = await UserService.GetUserById(Guid.Parse(UserId));
        }

        protected async Task HandleValidSubmit()
        {
            UserCommand.Id = Guid.Parse(UserId);
            UserCommand.FirstName = Profile.FirstName;
            UserCommand.LastName = Profile.LastName;
            UserCommand.UserName = Profile.UserName;
            UserCommand.Email = Profile.Email;
            UserCommand.Description = Profile.Description;
            UserCommand.ProfilePicture = Profile.ProfilePicture;

            UserCommand.Role = Profile.Role;

            await UserService.UpdateUser(UserCommand);

            NavigationManager.NavigateTo("/Profile/" + UserId);
        }
    }
}
