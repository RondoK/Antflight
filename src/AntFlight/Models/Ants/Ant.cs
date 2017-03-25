using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;

namespace AntFlight.Models.Ants
{
    public class Ant
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string SpeciesName { get; set; }

        public int GenusId { get; set; }
        public Genus Genus { get; set; }

        public int? SubgenusId { get; set; }
        public Subgenus Subgenus { get; set; }

        public OriginalFlightTime OriginalFlightTime { get; set; }

        public ICollection<FlightMessages.FlightMessage> FlightMessages { get; set; }
    }
}