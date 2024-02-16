using AutoMapper;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.mapper
{
    public class Profiles : AutoMapper.Profile
    {
        public Profiles()
        {
            CreateMap<Activity, ActivityDTO>().ReverseMap();
        }
    }
}
