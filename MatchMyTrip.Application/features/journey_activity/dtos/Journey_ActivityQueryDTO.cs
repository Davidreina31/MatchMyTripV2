using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Application.features.journey_activity.dtos
{
    public class Journey_ActivityQueryDTO
    {
        public Guid Id { get; set; }

        public Guid JourneyId { get; set; }

        public JourneyDTO Journey { get; set; }

        public Guid ActivityId { get; set; }

        public ActivityDTO Activity { get; set; }
    }
}
