using AutoMapper;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey_activity.dto;
using MatchMyTrip.Application.features.match.dto;
using MatchMyTrip.Application.features.match_activity.dto;
using MatchMyTrip.Application.features.user.dtos;
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
            CreateMap<MatchMyTrip.Domain.entities.User, UserQueryDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.Match, MatchDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.Journey_Activity, Journey_ActivityDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.Journey_Activity, Journey_ActivityQueryDTO>().ReverseMap();
            CreateMap<MatchMyTrip.Domain.entities.Match_Activity, Match_ActivityDTO>().ReverseMap();
        }
    }
}
