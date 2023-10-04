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
    public class RoomServicesController : Controller
    {
        private readonly HotelContext _context;

        public RoomServicesController(HotelContext context)
        {
            _context = context;
        }

        // GET: RoomServices
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.RoomService.Include(r => r.Room).Include(r => r.Staff);
            return View(await hotelContext.ToListAsync());
        }

        // GET: RoomServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RoomService == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService
                .Include(r => r.Room)
                .Include(r => r.Staff)
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (roomService == null)
            {
                return NotFound();
            }

            return View(roomService);
        }

        // GET: RoomServices/Create
        public IActionResult Create()
        {
            ViewData["RoomID"] = new SelectList(_context.Room, "room_ID", "room_Description");
            ViewData["staffID"] = new SelectList(_context.Set<Staff>(), "staff_ID", "staff_Address");
            return View();
        }

        // POST: RoomServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Type,staffID,RoomID,Status")] RoomService roomService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "room_ID", "room_Description", roomService.RoomID);
            ViewData["staffID"] = new SelectList(_context.Set<Staff>(), "staff_ID", "staff_Address", roomService.staffID);
            return View(roomService);
        }

        // GET: RoomServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RoomService == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService.FindAsync(id);
            if (roomService == null)
            {
                return NotFound();
            }
            ViewData["RoomID"] = new SelectList(_context.Room, "room_ID", "room_Description", roomService.RoomID);
            ViewData["staffID"] = new SelectList(_context.Set<Staff>(), "staff_ID", "staff_Address", roomService.staffID);
            return View(roomService);
        }

        // POST: RoomServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Type,staffID,RoomID,Status")] RoomService roomService)
        {
            if (id != roomService.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomServiceExists(roomService.ServiceId))
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
            ViewData["RoomID"] = new SelectList(_context.Room, "room_ID", "room_Description", roomService.RoomID);
            ViewData["staffID"] = new SelectList(_context.Set<Staff>(), "staff_ID", "staff_Address", roomService.staffID);
            return View(roomService);
        }

        // GET: RoomServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RoomService == null)
            {
                return NotFound();
            }

            var roomService = await _context.RoomService
                .Include(r => r.Room)
                .Include(r => r.Staff)
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (roomService == null)
            {
                return NotFound();
            }

            return View(roomService);
        }

        // POST: RoomServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RoomService == null)
            {
                return Problem("Entity set 'HotelContext.RoomService'  is null.");
            }
            var roomService = await _context.RoomService.FindAsync(id);
            if (roomService != null)
            {
                _context.RoomService.Remove(roomService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomServiceExists(int id)
        {
          return (_context.RoomService?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
