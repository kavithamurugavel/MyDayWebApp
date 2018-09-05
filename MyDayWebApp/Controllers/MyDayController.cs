using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDayWebApp.Common;
using MyDayWebApp.Data;
using MyDayWebApp.DTOs;
using MyDayWebApp.Models.MyDay;
using MyDayWebApp.ViewModels;
using Newtonsoft.Json;

namespace MyDayWebApp.Controllers
{
    public class MyDayController : Controller
    {
        private ApplicationDbContext _context;
        ApiCall apiCall;

        public MyDayController(ApplicationDbContext context)
        {
            _context = context;
            apiCall = new ApiCall();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            MyDayViewModel viewModel = GetWeather();

            return View("Index", viewModel);
        }

        public MyDayViewModel GetWeather()
        {
            string jsonString = "";
            string apiEndPoint = "http://localhost:20208/api/weather?zip={0}";
           
            var currentUserID = User.Claims.ToList()[0].Value; // TODO: unsure if this is right, double check!
            var locations = _context.Location.ToList();
            var currentUserLocation = locations.SingleOrDefault(l => l.UserID == currentUserID).Zip;

            string apiString = string.Format(apiEndPoint, currentUserLocation);

            jsonString = apiCall.GetJSONStringFromAPI(apiString);

            var weather = JsonConvert.DeserializeObject<WeatherDTO>(jsonString);

            // TODO: separate the reminders part 
            MyDayViewModel viewModel = new MyDayViewModel()
            {
                WeatherInfo = weather,
                Reminders = new List<Reminder>()
            };

            return viewModel;
        }
    }
}