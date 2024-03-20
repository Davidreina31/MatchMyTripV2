using Auth0.AspNetCore.Authentication;
using Blazored.LocalStorage;
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.user.commands.createUserCommand;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public IUserService UserService { get; set; }

        public List<UserDTO> Users { get; set; } = new List<UserDTO>();

        public CreateUserCommand CreateCommand { get; set; } = new CreateUserCommand();

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

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
            if (firstRender && !localStorageSaved)
            {
                var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
                Sub = authstate.User.Claims.ToList()[4].Value;

                await SaveUserDataToLocalStorage("userData", Sub); // Sauvegarder les données dans le LocalStorage
                localStorageSaved = true; // Marquer que les données ont été sauvegardées
            }
        }

        private async Task SaveUserDataToLocalStorage(string key, string data)
        {
            await LocalStorageService.SetItemAsync(key, data);
        }
    }
}