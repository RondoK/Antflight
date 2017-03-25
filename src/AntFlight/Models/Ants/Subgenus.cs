using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;

namespace AntFlight.Models.Ants
{
    public class Subgenus
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string SubgenusName { get; set; }

        public int GenusId { get; set; }
        public Genus Genus { get; set; }
    }
}