using MatchMyTrip.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.contracts
{
    public interface IMatchRepository 
    {
        Task<List<Match>> GetAllByUserId(Guid id);
        Task<List<Match>> GetAllByJourneyId(Guid id);
    }
}
