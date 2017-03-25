using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using AntFlight.Models.Ants;


namespace AntFlight.Models.FlightMessages
{
    public class FlightMessage
    {
        public int Id { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int AntId { get; set; }
        public Ant Ant { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public DateTime MessageTime { get; set; }

        [Required]
        public DateTime FlightTime { get; set; }

        public FlightMessageDiscription FMDiscription { get; set; }
    }
}
