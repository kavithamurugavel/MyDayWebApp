using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyDayWebApp.Data;
using MyDayWebApp.Models.Settings;

namespace MyDayWebApp.Controllers
{
    public class SettingsController : Controller
    {
        private ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            return View();
        }

        // method to save or display the location of the user
        public IActionResult SaveOrDisplayZip(Location location)
        {
            var locations = _context.Location.ToList();
            var currentUserID = User.Claims.ToList()[0].Value; // TODO: unsure if this is right, double check!

            var currentUserLocation = locations.SingleOrDefault(l => l.UserID == currentUserID);
            if (currentUserLocation == null)
            {
                Location newLocation = new Location()
                {
                    UserID = currentUserID,
                    Zip = location.Zip
                };
                _context.Location.Add(newLocation);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", currentUserLocation);
        }
    }
}