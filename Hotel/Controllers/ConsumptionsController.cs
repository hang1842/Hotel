using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class ConsumptionsController : Controller
    {
        private readonly HotelContext _context;

        public ConsumptionsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Consumptions
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Consumption.Include(c => c.guest).Include(c => c.service);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Consumptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consumption == null)
            {
                return NotFound();
            }

            var consumption = await _context.Consumption
                .Include(c => c.guest)
                .Include(c => c.service)
                .FirstOrDefaultAsync(m => m.con_ID == id);
            if (consumption == null)
            {
                return NotFound();
            }

            return View(consumption);
        }

        // GET: Consumptions/Create
        public IActionResult Create()
        {
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email");
            ViewData["BS_ID"] = new SelectList(_context.BusinessService, "BS_ID", "BS_Name");
            return View();
        }

        // POST: Consumptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("con_ID,guestID,BS_ID,Service_Quantity,con_Amount")] Consumption consumption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email", consumption.guestID);
            ViewData["BS_ID"] = new SelectList(_context.BusinessService, "BS_ID", "BS_Name", consumption.BS_ID);
            return View(consumption);
        }

        // GET: Consumptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consumption == null)
            {
                return NotFound();
            }

            var consumption = await _context.Consumption.FindAsync(id);
            if (consumption == null)
            {
                return NotFound();
            }
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email", consumption.guestID);
            ViewData["BS_ID"] = new SelectList(_context.BusinessService, "BS_ID", "BS_Name", consumption.BS_ID);
            return View(consumption);
        }

        // POST: Consumptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("con_ID,guestID,BS_ID,Service_Quantity,con_Amount")] Consumption consumption)
        {
            if (id != consumption.con_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumptionExists(consumption.con_ID))
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
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email", consumption.guestID);
            ViewData["BS_ID"] = new SelectList(_context.BusinessService, "BS_ID", "BS_Name", consumption.BS_ID);
            return View(consumption);
        }

        // GET: Consumptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consumption == null)
            {
                return NotFound();
            }

            var consumption = await _context.Consumption
                .Include(c => c.guest)
                .Include(c => c.service)
                .FirstOrDefaultAsync(m => m.con_ID == id);
            if (consumption == null)
            {
                return NotFound();
            }

            return View(consumption);
        }

        // POST: Consumptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consumption == null)
            {
                return Problem("Entity set 'HotelContext.Consumption'  is null.");
            }
            var consumption = await _context.Consumption.FindAsync(id);
            if (consumption != null)
            {
                _context.Consumption.Remove(consumption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumptionExists(int id)
        {
          return (_context.Consumption?.Any(e => e.con_ID == id)).GetValueOrDefault();
        }
    }
}
