using MatchMyTrip.Application.features.user.common;
using MatchMyTrip.Domain.enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.commands.createUserCommand
{
    public class CreateUserCommand : IRequest<UserCommandResponse>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public byte[] ImageContent { get; set; }

        public string? ImageName { get; set; }
    }
}
