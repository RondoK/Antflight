using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AntFlight.Models.FlightMessages
{
    public class FlightMessageDiscription
    {
        [Key]
        [ForeignKey("FlightMessage")]
        public int FlightMessageId { get; set; }
        public FlightMessage FlightMessage { get; set; }

        [Required]
        [Display(Name = "Интенсивность лёта")]
        public byte FlightIntensity { get; set; }

        [Display(Name = "Температура")]
        public byte Temperature { get; set; }

        [Display(Name = "Осадки")]
        public byte Precipitation { get; set; }

        [Display(Name = "Небо")]
        public byte Sky { get; set; }

        [Display(Name = "Ветер")]
        public byte Wind { get; set; }

        [Display(Name = "Местность")]
        public byte Terrain { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        public static List<string> GetFlightIntensityList
        {
            get
            {
                return new List<string> {
                    "Выберите интенсивность лёта",
                    "Одна королева",
                    "Несколько королев",
                    "Слабый лёт",
                    "Массовый лёт"
                };

            }
        }
        public static List<string> GetTemperatureList
        {
            get
            {
                return new List<string> {
                    "Выберите Температуру",
                };
            }
        }
        public static List<string> GetPrecipitationList
        {
            get
            {
                return new List<string> {
                    "Выберите тип осадки",
                    "Осадков не наблюдалось",
                    "Незадолго до лёта были осадки",
                    "Сразу после лёта был дождь",
                    "Лёт происходил во время небольшого дождя"
                };
            }
        }
        public static List<string> GetSkyList
        {
            get
            {
                return new List<string>
                {
                    "Выберите состояние неба",
                    "Солнечно",
                    "Облачно",
                    "Пасмурно",
                    "Туман"
                };
            }
        }
        public static List<string> GetWindList
        {
            get
            {
                return new List<string>
                {
                    "Выберите силу ветра",
                    "Безветренно",
                    "Слабый ветер",
                    "Ветренно"
                };
            }
        }
        public static List<string> GetTerrainList
        {
            get
            {
                return new List<string>
                {
                    "Выберите тип местности",
                    "Город",
                    "Парк",
                    "Пригород",
                    "Лес",
                    "Парк",
                    "Поляна",
                    "Недалеко от водоёма",
                    "Сельская местность",
                    "Степь",
                    "Пустошь"
                };
            }
        }
    }


    
}