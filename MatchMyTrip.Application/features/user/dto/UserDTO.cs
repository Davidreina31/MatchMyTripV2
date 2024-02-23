﻿using MatchMyTrip.Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.dto
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Description { get; set; }

        public string ProfilePicture { get; set; }

        public Roles Role { get; set; }

    }
}
