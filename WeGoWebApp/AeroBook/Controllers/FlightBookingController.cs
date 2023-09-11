using AeroBook.Data;
using AeroBook.ViewModels.Flights;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AeroBook.Controllers
{
    public class FlightBookingController : Controller
    {
        private readonly AeroBookDbContext _context;
        public FlightBookingController(AeroBookDbContext context)
        {
            _context = context;
        }


        public IActionResult FlightBookingView()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Filter(string FromLocation,string ToLocation,DateTime Departure, string person)
        {
            List<Flightdetails> items = new List<Flightdetails>();
        
            ViewData["FromLocation"] = FromLocation;
            ViewData["ToLocation"] = ToLocation;
            if (string.IsNullOrEmpty(FromLocation))
            {
                // If no category is selected, show all items
                return View("FlightBookingView", items);
            }

            var filteredItems = _context.Flightdetails.Where(item => item.FromLocation == FromLocation).ToList();
            foreach (var item in filteredItems)
            {
                Flightdetails flightdetails= new Flightdetails();
                flightdetails.DepartureDate = item.DepartureDate;
                flightdetails.ArrivalTime = item.ArrivalTime;   
                flightdetails.Availability = item.Availability;
                flightdetails.FlightName = item.FlightName; 
                flightdetails.PricePerPerson = item.PricePerPerson;
                flightdetails.FlightId = item.FlightId;
                items.Add(flightdetails);
            }
            return View("FlightBookingView", items);
        }

        [HttpPost]
        public IActionResult Save(List<Flightdetails> selectedItems)
        {
            // Redirect to the Payment Index action after saving
            return RedirectToAction("Index", "Payment");
        }
    }
}