using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using AntFlight.Models.Ants;


namespace AntFlight.Models.FlightMessages
{
    public class FlightMessage
    {
        public int Id { get; set; }

        [Required]
        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Город")]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required(ErrorMessage = " обязательное поле")]
        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Вид")]
        public int AntId { get; set; }
        public Ant Ant { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime MessageTime { get; set; }

        [Required(ErrorMessage = "Время лёта - обязательное поле")]
        [Display(Name = "Время Лёта")]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FlightTime { get; set; }

        [Required(ErrorMessage = "FMDescr")]
        public FlightMessageDescription FMDescription { get; set; }
    }
}
