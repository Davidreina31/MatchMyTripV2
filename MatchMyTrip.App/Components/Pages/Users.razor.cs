using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Users
    {
        [Inject]
        public IUserService UserService { get; set; }

        public List<UserDTO> UserList { get; set; } = new List<UserDTO>();

        protected override async Task OnInitializedAsync()
        {
            UserList = await UserService.GetUsers();
        }
    }
}
