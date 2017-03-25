using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AntFlight.Models.FlightMessages
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength (30)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
