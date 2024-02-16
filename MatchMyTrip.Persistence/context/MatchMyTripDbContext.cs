using MatchMyTrip.Domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Persistence.context
{
    public class MatchMyTripDbContext : DbContext
    {
        public MatchMyTripDbContext(DbContextOptions<MatchMyTripDbContext> options) : base(options)
        {
            
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<Journey_Activity> Journey_Activities { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Match_Activity> Match_Activities { get; set; }
        public DbSet<Match_Profile> Match_Profiles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Profile_Filter> Profile_Filters { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
