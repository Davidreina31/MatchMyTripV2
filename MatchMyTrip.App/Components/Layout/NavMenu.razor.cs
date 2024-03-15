using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace MatchMyTrip.App.Components.Layout
{
    public partial class NavMenu
    {
        [Inject]
        public IUserService UserService { get; set; }

        public UserDTO CurrentUser { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationState { get; set; }
       

        protected override async Task OnInitializedAsync()
        {
            if(AuthenticationState is not null)
            {
                var state = await AuthenticationState;

                if (state.User.Identity.IsAuthenticated)
                {
                    CurrentUser = await UserService.GetUserByEmail(state.User.Identity.Name);
                }
            }
        }
    }
}
