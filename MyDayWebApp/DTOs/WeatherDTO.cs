using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDayWebApp.DTOs
{
    public class WeatherDTO
    {
        public int id { get; set; } // city id
        public string name { get; set; } // city name
        public Main main { get; set; }
    }
}
