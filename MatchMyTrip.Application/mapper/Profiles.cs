using AutoMapper;
using MatchMyTrip.Application.features.activity.dto;
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
        }
    }
}
