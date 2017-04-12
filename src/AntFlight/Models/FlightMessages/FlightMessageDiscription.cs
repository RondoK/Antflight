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
        [Required]
        [Display(Name ="Сила лёта")]
        [MaxLength(50)]
        public string FlightIntensity { get; set; }

        [Display(Name = "Температура")]
        [MaxLength(30)]
        public string Temperature { get; set; }

        [Display(Name = "Осадки")]
        [MaxLength(30)]
        public string Precipitation { get; set; }

        [Display(Name = "Небо")]
        [MaxLength(30)]
        public string Sky { get; set; }

        [Display(Name = "Ветер")]
        [MaxLength(30)]
        public string Wind { get; set; }

        [Display(Name = "Местность")]
        [MaxLength(30)]
        public string Terrain { get; set; }

        [Display(Name ="Описание")]
        public string Description { get; set; }
    }
}