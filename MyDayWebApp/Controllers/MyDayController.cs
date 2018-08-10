using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDayWebApp.Data;
using MyDayWebApp.DTOs;
using Newtonsoft.Json;

namespace MyDayWebApp.Controllers
{
    public class MyDayController : Controller
    {
        private ApplicationDbContext _context;

        public MyDayController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            string jsonString = "";
            string apiEndPoint = "http://localhost:17368/api/weather?zip={0}";
            var currentUserID = User.Claims.ToList()[0].Value; // TODO: unsure if this is right, double check!
            var locations = _context.Location.ToList();
            var currentUserLocation = locations.SingleOrDefault(l => l.UserID == currentUserID).Zip;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(string.Format(apiEndPoint, currentUserLocation));
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponseAsync().Result;

            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            var weather = JsonConvert.DeserializeObject<WeatherDTO>(jsonString);
            return View("Index", weather);
        }
    }
}