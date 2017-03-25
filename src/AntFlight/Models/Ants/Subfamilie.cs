using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;

namespace AntFlight.Models.Ants
{
    public class Subfamilie
    {
        public int Id {get;set;}
        [Required]
        [MaxLength(30)]
        public string SubfamilieName { get; set;}
    }
}