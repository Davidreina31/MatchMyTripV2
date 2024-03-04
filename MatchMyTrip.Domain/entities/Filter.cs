using MatchMyTrip.Domain.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMyTrip.Domain.entities
{
    public class Filter
    {
        //public Guid Id { get; set; }

        public string Destination { get; set; }

        public int NbrOfDays { get; set; }

        public Seasons Seasons { get; set; }
    }
}
