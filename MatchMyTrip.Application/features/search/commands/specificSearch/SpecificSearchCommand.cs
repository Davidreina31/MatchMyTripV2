using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.search.commands.specificSearch
{
    public class SpecificSearchCommand : IRequest<List<JourneyDTO>>
    {
        public FilterDTO Filter { get; set; }
    }
}
