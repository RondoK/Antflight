using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntFlight.Models
{
    public class FlightTimetableLine
    {
        public string Name { get; set; }
        public int[,] Months { get; set; }

        public FlightTimetableLine ()
        {
            Months = new int[12 , 4];
        }
        public FlightTimetableLine (string name , int val = 4)
        {
            Name = name;
            Months = new int[12 , val];
        }
    }
}
