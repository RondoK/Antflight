using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntFlight.Models.Ants
{
    public class OriginalFlightTime
    {
        [Key]
        [ForeignKey("Ant")]
        public int AntId { get; set;}
        public Ant Ant { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FlightStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime FlightEnd { get; set; }

        [MaxLength(150)]
        public string SourceName { get; set; }

    }
}