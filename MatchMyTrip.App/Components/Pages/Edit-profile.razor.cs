
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.App.services;
using MatchMyTrip.Application.features.user.commands.updateUserCommand;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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

        private IBrowserFile selectedFile;

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            if(selectedFile != null)
            {
                var file = selectedFile;
                Stream stream = file.OpenReadStream();
                MemoryStream ms = new();
                await stream.CopyToAsync(ms);
                stream.Close();

                UserCommand.ImageName = file.Name;
                UserCommand.ImageContent = ms.ToArray();
            }

            UserCommand.Id = Guid.Parse(UserId);
            UserCommand.FirstName = Profile.FirstName;
            UserCommand.LastName = Profile.LastName;
            UserCommand.UserName = Profile.UserName;
            UserCommand.Email = Profile.Email;
            UserCommand.Sub = Profile.Sub;
            UserCommand.Description = Profile.Description;
            if (selectedFile == null)
            {
                UserCommand.ImageName = Profile.ImageName;
                UserCommand.ImageContent = Profile.ImageContent;
            }

            UserCommand.Role = Profile.Role;

            await UserService.UpdateUser(UserCommand);

            NavigationManager.NavigateTo("/Profile/" + UserId);
        }
    }
}
