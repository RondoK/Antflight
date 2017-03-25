using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntFlight.Models
{
    public class FlightMessagesView
    {
        public int Id { get; set; }

        public string Species { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        public DateTime FlightTime { get; set; }
    }
}
