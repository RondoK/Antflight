using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntFlight.Models.FlightMessages
{
    public class FlightMessageDiscription
    {
        [Key]
        [ForeignKey("FlightMessage")]
        public int FlightMessageId { get; set; } 
        public FlightMessage FlightMessage { get; set; }

        public string Description { get; set; }
    }
}
