using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AntFlight.Models.FlightMessages
{
    public class FlightMessageDescription
    {
        [Key]
        [ForeignKey("FlightMessage")]
        public int FlightMessageId { get; set; }
        public FlightMessage FlightMessage { get; set; }

        [Required(ErrorMessage = "Intens")]
        [Display(Name = "Интенсивность лёта")]
        [Range(1 , int.MaxValue , ErrorMessage = "Выберите Интенсивность лёта")]
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

        public static string[] GetFlightIntensityArr
        {
            get
            {
                return new string[] {
                    "Выберите интенсивность лёта",
                    "Одна королева",
                    "Несколько королев",
                    "Слабый лёт",
                    "Массовый лёт"
                };
            }
        }
        public static string[] GetTemperatureArr
        {
            get
            {
                return new string[] {
                    "Выберите Температуру",
                };
            }
        }
        public static string[] GetPrecipitationArr
        {
            get
            {
                return new string[] {
                    "Выберите тип осадки",
                    "Осадков не наблюдалось",
                    "Незадолго до лёта были осадки",
                    "Сразу после лёта был дождь",
                    "Лёт происходил во время небольшого дождя"
                };
            }
        }
        public static string[] GetSkyArr
        {
            get
            {
                return new string[]
                {
                    "Выберите состояние неба",
                    "Солнечно",
                    "Облачно",
                    "Пасмурно",
                    "Туман"
                };
            }
        }
        public static string[] GetWindArr
        {
            get
            {
                return new string[]
                {
                    "Выберите силу ветра",
                    "Безветренно",
                    "Слабый ветер",
                    "Ветренно"
                };
            }
        }
        public static string[] GetTerrainArr
        {
            get
            {
                return new string[]
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

        public static SelectList GetSelectList (int selectedId , string[] arr)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            for (int i = 0 ; i < arr.Length ; i++)
            {
                selectList.Add(new SelectListItem
                {
                    Value = i.ToString() ,
                    Text = arr[i] ,
                    Selected = i == selectedId
                });

            }
            return new SelectList(selectList , "Value" , "Text");
        }
    }



}