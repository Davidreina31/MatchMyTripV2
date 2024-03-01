using MatchMyTrip.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.contracts
{
    public interface ISearchRepository
    {
        Task<List<User>> GetMatchListByKeyWord(string keyWord);
        Task<List<Journey>> GetMatchListByFilters(Filter filter);
    }
}
