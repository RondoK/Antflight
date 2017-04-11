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
        [Range(1 , int.MaxValue)]
        [Display(Name = "Город")]
        public int CityId { get; set; }
        public string CityName { get; set; }

        [Required]
        [Range(1 , int.MaxValue)]
        [Display(Name = "Страна")]
        public int CountryId { get; set; }
        public string CountryName { get; set; }


        [Required]
        [Range(1 , int.MaxValue)]
        [Display(Name = "Вид")]
        public int AntId { get; set; }
        public string AntName { get; set; }

        [Required]
        [Range(1 , int.MaxValue)]
        [Display(Name = "Род")]
        public int GenusId { get; set; }
        public string GenusName { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        [Display(Name = "Подсемейство")]
        public int SubfamilieId { get; set; }
        public string SubfamilieName { get; set; }

        [Display(Name ="Пользователь")]
        public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Время лёта")]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime MessageTime { get; set; }

        [Required]
        [Display(Name = "Время Лёта")]
        [DisplayFormat(ApplyFormatInEditMode = true , DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime FlightTime { get; set; }

        public FlightMessageDiscription FMDiscription { get; set; }
    }
}
