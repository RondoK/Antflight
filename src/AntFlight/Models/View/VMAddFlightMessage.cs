using AntFlight.Models.FlightMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AntFlight.Models.View
{
    public class VMAddFlightMessage
    {
        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Вид")]
        public int SpeciesId { get; set; }
        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Род")]
        public int GenusId { get; set; }

        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Подсемейство")]
        public int SubfamilieId { get; set; }

        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Город")]
        public int CityId { get; set; }

        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Страну")]
        public int CountryId { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Display(Name = "Время Лёта")]
        [Required(ErrorMessage = "Время лёта - обязательное поле")]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FlightTime { get; set; }

        [Required(ErrorMessage = "FMDescr")]
        public FlightMessageDescription FMDescription { get; set; }
    }
}
