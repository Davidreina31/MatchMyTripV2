﻿using MatchMyTrip.App.services;
using MatchMyTrip.Application.features.user.dtos;
using Microsoft.AspNetCore.Components;

namespace MatchMyTrip.App.Components.Pages
{
    public partial class Login
    {
        [Inject]
        public SharedService SharedService { get; set; }

        public UserDTO CurrentUser { get; set; } = new UserDTO();

        protected override async Task OnInitializedAsync()
        {
            CurrentUser = await SharedService.GetCurrentUser();
        }
    }
}
