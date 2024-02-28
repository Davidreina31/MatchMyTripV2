using MatchMyTrip.Application.contracts;
using MatchMyTrip.Application.features.user.dtos;
using MatchMyTrip.Domain.entities;
using MatchMyTrip.Persistence.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Persistence.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MatchMyTripDbContext _context;

        public UserRepository(MatchMyTripDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _context.Users.Include(x => x.Journeys).Include(x => x.Matches).FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
    }
}
