﻿using MatchMyTrip.Application.features.user.dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.search.commands.searchByKeyWord
{
    public class SearchByKeyWordCommand : IRequest<List<UserQueryDTO>>
    {
        public string KeyWord { get; set; }
    }
}
