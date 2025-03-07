﻿using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Layout
{
    public partial class NavMenu
    {
        [Inject]
        public ISharedService SharedService { get; set; }

        public UserDTO CurrentUser { get; set; } = new UserDTO();

        protected override async Task OnInitializedAsync()
        {
            CurrentUser = await SharedService.GetCurrentUser();
        }
    }
}
