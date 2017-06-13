using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;

namespace AntFlight.Models.Ants
{
    public class Genus
    {
        public int Id { get; set;}

        [MaxLength(30)]
        public string GenusName { get; set; }

        [Required]
        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Подсемейство")]
        public int SubfamilieId { get; set; }
        public Subfamilie Subfamilie {get; set;}
        
    }
}