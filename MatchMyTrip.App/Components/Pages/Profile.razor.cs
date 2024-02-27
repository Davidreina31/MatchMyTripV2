using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.user.dto;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Profile
    {
        [Inject]
        public IUserService UserService { get; set; }

        public List<UserDTO> Users { get; set; } = new List<UserDTO>();

        public UserDTO User { get; set; } = new UserDTO();

        protected override async Task OnInitializedAsync()
        {
            var s = "DE1152A3-7DF4-4548-E134-08DC3452ABC2".ToLower();
            User = await UserService.GetUserById(Guid.Parse(s));
        }

    }
}
