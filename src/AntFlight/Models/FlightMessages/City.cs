using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AntFlight.Models.FlightMessages
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength (30)]
        [Display(Name = "Город")]
        public string Name { get; set; }

        [Required]
        [Range(1 , int.MaxValue)]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
