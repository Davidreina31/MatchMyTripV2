using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.user.commands.createUserCommand;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public ISessionService SessionService { get; set; }

        [Inject]
        public IlocalStorageService LocalStorageService { get; set; }

        public List<UserDTO> Users { get; set; } = new List<UserDTO>();

        public CreateUserCommand CreateCommand { get; set; } = new CreateUserCommand();

        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        private string Email = "";

        private string? Sub;

        private bool AlreadyExists = false;

        private bool localStorageSaved = false;

        protected override async Task OnInitializedAsync()
        {
            Users = await UserService.GetUsers();

            var state = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();

            if (state.User.Identity.IsAuthenticated)
            {
                Email = state?.User?.Identity?.Name ?? string.Empty;

                if (Email != "")
                {
                    foreach (var user in Users)
                    {
                        if (user.Email == Email)
                        {
                            AlreadyExists = true;
                            break;
                        }
                    }

                    Sub = state.User.Claims.ToList()[4].Value ?? string.Empty;

                    if (!AlreadyExists)
                    {
                        CreateCommand.Email = Email;
                        CreateCommand.Description = "";
                        CreateCommand.FirstName = "";
                        CreateCommand.LastName = "";
                        CreateCommand.UserName = state.User.Claims.FirstOrDefault().Value.ToString();
                        CreateCommand.Sub = Sub;
                        CreateCommand.ImageContent = new byte[0];

                        await UserService.CreateUser(CreateCommand);
                    }
                }
            }

            StateHasChanged();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var state = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();

            if (firstRender && !localStorageSaved && state.User.Identity.IsAuthenticated)
            {
                var token = await SessionService.GetAccessToken();

                await LocalStorageService.SetItem("token", token);
                localStorageSaved = true; // Marquer que les données ont été sauvegardées
            }

            else if (!state.User.Identity.IsAuthenticated)
            {
                await LocalStorageService.RemoveItem("token");
            }
        }
    }
}