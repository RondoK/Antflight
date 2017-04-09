using AntFlight.Models.FlightMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AntFlight.Models
{
    public class FlightMessageView
    {
        [Required]
        [Display(Name = "Город")]
        public City City { get; set; }

        [Required]
        [Display(Name = "Страна")]
        public Country Country { get; set; }

        [Required]
        [Display(Name = "Вид")]
        public Ants.Ant Ant { get; set; }
        
        [Display(Name ="Пользователь")]
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Время лёта")]
        public DateTime MessageTime { get; set; }

        [Required]
        [Display(Name = "Время Лёта")]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FlightTime { get; set; }

        public FlightMessageDiscription FMDiscription { get; set; }
    }
}
