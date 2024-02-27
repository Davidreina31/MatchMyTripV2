using MatchMyTrip.Application.contracts;
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
    public class MatchRepository : IMatchRepository
    {
        private readonly MatchMyTripDbContext _context;

        public MatchRepository(MatchMyTripDbContext context)
        {
            _context = context;
        }

        public async Task<List<Match>> GetAllByJourneyId(Guid id)
        {
            var matches = await _context.Matches.Where(x => x.JourneyId == id).ToListAsync();

            return matches;
        }

        public async Task<List<Match>> GetAllByUserId(Guid id)
        {
            var matches = await _context.Matches.Where(x => x.UserId == id).ToListAsync();

            return matches;
        }
    }
}
