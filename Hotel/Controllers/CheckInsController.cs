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
    public class CheckInsController : Controller
    {
        private readonly HotelContext _context;

        public CheckInsController(HotelContext context)
        {
            _context = context;
        }

        // GET: CheckIns
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.CheckIn.Include(c => c.guest).Include(c => c.room);
            return View(await hotelContext.ToListAsync());
        }

        // GET: CheckIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CheckIn == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIn
                .Include(c => c.guest)
                .Include(c => c.room)
                .FirstOrDefaultAsync(m => m.CheckId == id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return View(checkIn);
        }

        // GET: CheckIns/Create
        public IActionResult Create()
        {
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email");
            ViewData["roomID"] = new SelectList(_context.Set<Room>(), "room_ID", "room_Description");
            return View();
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckId,guestID,roomID,CheckInDate,CheckOutDate,pre_payment_amount,pre_payment_method")] CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email", checkIn.guestID);
            ViewData["roomID"] = new SelectList(_context.Set<Room>(), "room_ID", "room_Description", checkIn.roomID);
            return View(checkIn);
        }

        // GET: CheckIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CheckIn == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIn.FindAsync(id);
            if (checkIn == null)
            {
                return NotFound();
            }
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email", checkIn.guestID);
            ViewData["roomID"] = new SelectList(_context.Set<Room>(), "room_ID", "room_Description", checkIn.roomID);
            return View(checkIn);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckId,guestID,roomID,CheckInDate,CheckOutDate,pre_payment_amount,pre_payment_method")] CheckIn checkIn)
        {
            if (id != checkIn.CheckId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckInExists(checkIn.CheckId))
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
            ViewData["guestID"] = new SelectList(_context.Set<Guest>(), "GuestID", "Email", checkIn.guestID);
            ViewData["roomID"] = new SelectList(_context.Set<Room>(), "room_ID", "room_Description", checkIn.roomID);
            return View(checkIn);
        }

        // GET: CheckIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CheckIn == null)
            {
                return NotFound();
            }

            var checkIn = await _context.CheckIn
                .Include(c => c.guest)
                .Include(c => c.room)
                .FirstOrDefaultAsync(m => m.CheckId == id);
            if (checkIn == null)
            {
                return NotFound();
            }

            return View(checkIn);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CheckIn == null)
            {
                return Problem("Entity set 'HotelContext.CheckIn'  is null.");
            }
            var checkIn = await _context.CheckIn.FindAsync(id);
            if (checkIn != null)
            {
                _context.CheckIn.Remove(checkIn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckInExists(int id)
        {
          return (_context.CheckIn?.Any(e => e.CheckId == id)).GetValueOrDefault();
        }
    }
}
