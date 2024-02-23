using MatchMyTrip.Application.features.user.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.user.commands.deleteUserCommand
{
    public class DeleteUserCommand : IRequest<UserCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
