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
    public class Journey_ActivityRepository : IJourney_ActivityRepository
    {
        private readonly MatchMyTripDbContext _context;

        public Journey_ActivityRepository(MatchMyTripDbContext context)
        {
            _context = context;
        }

        public async Task<List<Journey_Activity>> GetAllByJourneyId(Guid id)
        {
            var journey_activities = await _context.Journey_Activities.Include(x => x.Journey).Include(x => x.Activity).Where(x => x.JourneyId == id).ToListAsync();

            return journey_activities;
        }
    }
}
