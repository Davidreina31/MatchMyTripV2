using AutoMapper;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey_activity.dto;
using MatchMyTrip.Application.features.match.dto;
using MatchMyTrip.Application.features.user.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<MatchMyTrip.Domain.entities.Activity, ActivityDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.Journey, JourneyDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.User, UserDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.Match, MatchDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.Journey_Activity, Journey_ActivityDTO>().ReverseMap();
        }
    }
}
