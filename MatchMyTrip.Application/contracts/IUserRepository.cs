using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.contracts
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid id);
    }
}
