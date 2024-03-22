using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components.Authorization;

namespace MatchMyTrip.App.services
{
    public class SharedService : ISharedService
    {
        private readonly AuthenticationStateProvider _authState;
        private readonly IUserService _userService;

        public SharedService(AuthenticationStateProvider authState, IUserService userService)
        {
            _authState = authState;
            _userService = userService;
        }

        public async Task<UserDTO> GetCurrentUser() 
        {
            UserDTO currentUser = new UserDTO();
            var state = await _authState.GetAuthenticationStateAsync();

            if (state.User.Identity.IsAuthenticated)
            {
                currentUser = await _userService.GetUserBySub(state.User.Claims.ToList()[4].Value.ToString());    
            }

            return currentUser;
        }
    }
}
