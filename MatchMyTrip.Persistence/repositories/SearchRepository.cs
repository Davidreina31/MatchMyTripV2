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
    public class SearchRepository : ISearchRepository
    {
        private readonly MatchMyTripDbContext _context;

        public SearchRepository(MatchMyTripDbContext context)
        {
            _context = context;
        }

        public async Task<List<Journey>> GetMatchListByFilters(Filter filter)
        {
            var result = await _context.Journeys.Where(x => x.Destination.ToLower().Contains(filter.Destination) &&
            (x.Seasons == filter.Seasons || x.NbrOfDays == filter.NbrOfDays)).ToListAsync();

            return result;
        }

        public async Task<List<User>> GetMatchListByKeyWord(string keyWord)
        {
            var result = await _context.Users.Include(x => x.Journeys).Where(x => x.UserName.ToLower().Contains(keyWord.ToLower()) ||
            x.Description.ToLower().Contains(keyWord.ToLower())
            || x.Journeys.Any(y => y.Destination.ToLower().Contains(keyWord.ToLower()))).ToListAsync();

            return result;
        }
    }
}
