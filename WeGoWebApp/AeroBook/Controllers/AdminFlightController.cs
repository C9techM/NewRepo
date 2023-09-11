using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AeroBook.Data;
using AeroBook.ViewModels.Flights;

namespace AeroBook.Controllers
{

    public class AdminFlightController : Controller
    {
        private readonly AeroBookDbContext _context;

        public AdminFlightController(AeroBookDbContext context)
        {
            _context = context;
        }

        // GET: Flightdetails
        public  IActionResult Index()
        {
            List<Flightdetails> details = new List<Flightdetails>();

            var data = _context.Flightdetails?.ToList();
            foreach(var d in data )
            {
                Flightdetails flightdetails= new Flightdetails();
                flightdetails.Availability = d.Availability;    
                flightdetails.ArrivalTime = d.ArrivalTime;  
                flightdetails.PricePerPerson = d.PricePerPerson;    
                flightdetails.DepartureDate= d.DepartureDate;
                flightdetails.FromLocation = d.FromLocation;    
                flightdetails.ToLocation = d.ToLocation;
                flightdetails.FlightName = d.FlightName; 
                flightdetails.FlightId = d.FlightId;
                details.Add(flightdetails);
            }
            return View(details);

        }

        // GET: Flightdetails/Details/5
        public IActionResult Details(int id)
        {
            Flightdetails details = new Flightdetails();



            var flightdetails =  _context.Flightdetails.Where(x => x.FlightId ==id).FirstOrDefault();
            details.ArrivalTime = flightdetails.ArrivalTime;
            details.DepartureDate = flightdetails.DepartureDate;
            details.PricePerPerson = flightdetails.PricePerPerson;
            details.FromLocation= flightdetails.FromLocation;
            details.ToLocation = flightdetails.ToLocation;
            details.Availability = flightdetails.Availability;
            details.FlightId = flightdetails.FlightId;
            details.FlightName =flightdetails.FlightName;

            if (flightdetails == null)
            {
                return NotFound();
            }

            return View(details);
        }

        // GET: Flightdetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flightdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Flightdetails flightdetails)
        {
            AeroBook.Data.Models.Flights.Flightdetails details = new Data.Models.Flights.Flightdetails();
            details.FlightName = flightdetails.FlightName;
            details.ArrivalTime=flightdetails.ArrivalTime;
            details.FromLocation = flightdetails.FromLocation;  
            details.ToLocation = flightdetails.ToLocation;
            details.PricePerPerson = flightdetails.PricePerPerson;  
            details.Availability = flightdetails.Availability;  
            details.DepartureDate = flightdetails.DepartureDate;
            details.FlightId= flightdetails.FlightId;   

                _context.Add(details);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
           
            return View(flightdetails);
        }

        // GET: Flightdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Flightdetails == null)
            {
                return NotFound();
            }

            var flightdetails = await _context.Flightdetails.FindAsync(id);
            if (flightdetails == null)
            {
                return NotFound();
            }
            AeroBook.ViewModels.Flights.Flightdetails details = new ViewModels.Flights.Flightdetails();
            details.ArrivalTime = flightdetails.ArrivalTime;
            details.PricePerPerson = flightdetails.PricePerPerson;
            details.Availability = flightdetails.Availability;
            details.DepartureDate = flightdetails.DepartureDate;
            details.FromLocation = flightdetails.FromLocation;
            details.ToLocation = flightdetails.ToLocation;
            details.FlightName = flightdetails.FlightName;
            details.FlightId= flightdetails.FlightId;

            return View(details);
        }

        //POST: Flightdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Flightdetails flightdetails)

        {
            AeroBook.Data.Models.Flights.Flightdetails details = new Data.Models.Flights.Flightdetails();

           
            try
                {
                details = _context.Flightdetails?.Where(x=>x.FlightId== flightdetails.FlightId)?.FirstOrDefault();

                details.FlightName = flightdetails.FlightName;
                details.ArrivalTime = flightdetails.ArrivalTime;
                details.FromLocation = flightdetails.FromLocation;
                details.ToLocation = flightdetails.ToLocation;
                details.PricePerPerson = flightdetails.PricePerPerson;
                details.Availability = flightdetails.Availability;
                details.DepartureDate = flightdetails.DepartureDate;

                _context.Update(details);
                _context.SaveChanges();
                }
                catch (Exception ex)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            
            return View(flightdetails);
        }

        // GET: Flightdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Flightdetails == null)
            {
                return NotFound();
            }

            var flightdetails = await _context.Flightdetails
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (flightdetails == null)
            {
                return NotFound();
            }
            AeroBook.ViewModels.Flights.Flightdetails details = new ViewModels.Flights.Flightdetails();
            details.ArrivalTime = flightdetails.ArrivalTime;
            details.PricePerPerson = flightdetails.PricePerPerson;
            details.Availability = flightdetails.Availability;
            details.DepartureDate = flightdetails.DepartureDate;
            details.FromLocation = flightdetails.FromLocation;
            details.ToLocation = flightdetails.ToLocation;
            details.FlightName = flightdetails.FlightName;
            details.FlightId = flightdetails.FlightId;
            return View(details);
        }

        // POST: Flightdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Flightdetails == null)
            {
                return Problem("Entity set 'AeroBookDbContext.Flightdetails'  is null.");
            }
            var flightdetails =  _context.Flightdetails.Find(id);
            if (flightdetails != null)
            {
                _context.Flightdetails.Remove(flightdetails);
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightdetailsExists(int id)
        {
          return (_context.Flightdetails?.Any(e => e.FlightId == id)).GetValueOrDefault();
        }
    }
}
