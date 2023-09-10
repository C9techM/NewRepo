using AeroBook.ViewModels.Flights;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AeroBook.Controllers
{
    public class FlightBookingController : Controller
    {
        public IActionResult FlightBookingView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Filter(string FromLocation,string ToLocation,DateTime Departure, string person)
        {
        List<Flightdetails> items = new List<Flightdetails>
        {
            new Flightdetails { FlightId = 1, FlightName = "Amigo",FromLocation="Hyder" ,ToLocation="sec",DepartureDate = DateTime.Now ,Availability="2",PricePerPerson =900 },
            new Flightdetails { FlightId = 2, FlightName = "T",FromLocation="Hydernagar",ToLocation="secf", DepartureDate = DateTime.Now,Availability="2" ,PricePerPerson =898},
            new Flightdetails { FlightId = 3, FlightName = "Airwo",FromLocation="Hydercev" ,ToLocation="sedb",DepartureDate = DateTime.Now , Availability = "2",PricePerPerson =909},
            // Add more items here
        };
            ViewData["FromLocation"] = FromLocation;
            ViewData["ToLocation"] = ToLocation;
            if (string.IsNullOrEmpty(FromLocation))
            {
                // If no category is selected, show all items
                return View("FlightBookingView", items);
            }

            var filteredItems = items.FindAll(item => item.FromLocation == FromLocation);
            return View("FlightBookingView", filteredItems);
        }

        [HttpPost]
        public IActionResult Save(List<Flightdetails> selectedItems)
        {

            // Redirect to the Index action after saving
            return RedirectToAction("Index", "Payment");

        }
    }
}