using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDayWebApp.DTOs
{
    public class Main
    {
        public double temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }

        // Kelvins to Fahrenheit
        public double CalculateKtoFTemp(double input)
        {
            return (1.8 * (input - 273) + 32);
        }
        // Kelvins to Celsius
        public double CalculateKtoCTemp(double input)
        {
            return (input - 273);
        }
    }
}
