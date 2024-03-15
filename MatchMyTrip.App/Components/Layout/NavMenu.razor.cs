using MatchMyTrip.App.Interfaces;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Layout
{
    public partial class NavMenu
    {
        [Inject]
        public IUserService UserService { get; set; }
    }
}
