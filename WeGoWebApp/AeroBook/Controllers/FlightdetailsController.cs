using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AeroBook.Data;
using AeroBook.Models.Flights;

namespace AeroBook.Controllers
{
    public class FlightdetailsController : Controller
    {
        private readonly AeroBookDbContext _context;

        public FlightdetailsController(AeroBookDbContext context)
        {
            _context = context;
        }

        // GET: Flightdetails
        public async Task<IActionResult> Index()
        {
            //return _context.Flightdetails != null ? 
            //            View(await _context.Flightdetails.ToListAsync()) :
            //            Problem("Entity set 'AeroBookDbContext.Flightdetails'  is null.");

            List<Flightdetails> detailsList = new List<Flightdetails>();

            Flightdetails details = new Flightdetails();

            details.ArrivalTime = DateTime.Now;
            details.FromLocation = "Chennai";

            detailsList.Add(details);
            
            



            return _context.Flightdetails != null ?
                          View(detailsList) :
                          Problem("Entity set 'AeroBookDbContext.Flightdetails'  is null.");
        }

        // GET: Flightdetails/Details/5
        public async Task<IActionResult> Details(string FromLocation,string ToLocation)
        {
            Flightdetails details = new Flightdetails();    

            details.ArrivalTime = DateTime.Now;
            details.FromLocation = "Chennai";

            //var flightdetails = await _context.Flightdetails.Where(x => x.FromLocation == FromLocation && x.ToLocation == ToLocation).ToListAsync();
                
            //if (flightdetails == null)
            //{
            //    return NotFound();
            //}

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
        public async Task<IActionResult> Create([Bind("FlightId,FightName,Availability,ArrivalTime,DepartureDate,FromLocation,ToLocation")] Flightdetails flightdetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightdetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(flightdetails);
        }

        // POST: Flightdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightId,FightName,Availability,ArrivalTime,DepartureDate,FromLocation,ToLocation")] Flightdetails flightdetails)
        {
            if (id != flightdetails.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightdetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightdetailsExists(flightdetails.FlightId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
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

            return View(flightdetails);
        }

        // POST: Flightdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Flightdetails == null)
            {
                return Problem("Entity set 'AeroBookDbContext.Flightdetails'  is null.");
            }
            var flightdetails = await _context.Flightdetails.FindAsync(id);
            if (flightdetails != null)
            {
                _context.Flightdetails.Remove(flightdetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightdetailsExists(int id)
        {
          return (_context.Flightdetails?.Any(e => e.FlightId == id)).GetValueOrDefault();
        }
    }
}
