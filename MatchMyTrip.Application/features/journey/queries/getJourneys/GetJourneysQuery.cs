using MatchMyTrip.Application.features.journey.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey.queries.getJournies
{
    public class GetJourneysQuery : IRequest<List<JourneyDTO>>
    {
    }
}
