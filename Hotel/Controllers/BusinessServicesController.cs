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
    public class BusinessServicesController : Controller
    {
        private readonly HotelContext _context;

        public BusinessServicesController(HotelContext context)
        {
            _context = context;
        }

        // GET: BusinessServices
        public async Task<IActionResult> Index()
        {
              return _context.BusinessService != null ? 
                          View(await _context.BusinessService.ToListAsync()) :
                          Problem("Entity set 'HotelContext.BusinessService'  is null.");
        }

        // GET: BusinessServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BusinessService == null)
            {
                return NotFound();
            }

            var businessService = await _context.BusinessService
                .FirstOrDefaultAsync(m => m.BS_ID == id);
            if (businessService == null)
            {
                return NotFound();
            }

            return View(businessService);
        }

        // GET: BusinessServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BS_ID,BS_Name,BS_Rate,BS_Price,BS_Description")] BusinessService businessService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessService);
        }

        // GET: BusinessServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BusinessService == null)
            {
                return NotFound();
            }

            var businessService = await _context.BusinessService.FindAsync(id);
            if (businessService == null)
            {
                return NotFound();
            }
            return View(businessService);
        }

        // POST: BusinessServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BS_ID,BS_Name,BS_Rate,BS_Price,BS_Description")] BusinessService businessService)
        {
            if (id != businessService.BS_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessServiceExists(businessService.BS_ID))
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
            return View(businessService);
        }

        // GET: BusinessServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BusinessService == null)
            {
                return NotFound();
            }

            var businessService = await _context.BusinessService
                .FirstOrDefaultAsync(m => m.BS_ID == id);
            if (businessService == null)
            {
                return NotFound();
            }

            return View(businessService);
        }

        // POST: BusinessServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BusinessService == null)
            {
                return Problem("Entity set 'HotelContext.BusinessService'  is null.");
            }
            var businessService = await _context.BusinessService.FindAsync(id);
            if (businessService != null)
            {
                _context.BusinessService.Remove(businessService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessServiceExists(int id)
        {
          return (_context.BusinessService?.Any(e => e.BS_ID == id)).GetValueOrDefault();
        }
    }
}
