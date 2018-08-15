using MyDayWebApp.DTOs;
using MyDayWebApp.Models.MyDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDayWebApp.ViewModels
{
    // TODO: change this so that only the required fields are listed
    public class MyDayViewModel
    {
        public WeatherDTO WeatherInfo { get; set; }

        public List<Reminder> Reminders { get; set; }
    }
}
