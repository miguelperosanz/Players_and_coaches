using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Players_and_coaches8.Data;
using Players_and_coaches8.Models;
using Microsoft.AspNetCore.Authorization;

namespace Players_and_coaches8.Controllers
{
    [Authorize]
    public class TransfersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransfersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transfers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transfers.ToListAsync());
        }

        // GET: Transfers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transfers = await _context.Transfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transfers == null)
            {
                return NotFound();
            }

            return View(transfers);
        }

        // GET: Transfers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,From,To")] Transfers transfers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transfers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transfers);
        }

        // GET: Transfers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transfers = await _context.Transfers.FindAsync(id);
            if (transfers == null)
            {
                return NotFound();
            }
            return View(transfers);
        }

        // POST: Transfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,From,To")] Transfers transfers)
        {
            if (id != transfers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transfers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransfersExists(transfers.Id))
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
            return View(transfers);
        }

        // GET: Transfers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transfers = await _context.Transfers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transfers == null)
            {
                return NotFound();
            }

            return View(transfers);
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transfers = await _context.Transfers.FindAsync(id);
            _context.Transfers.Remove(transfers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransfersExists(int id)
        {
            return _context.Transfers.Any(e => e.Id == id);
        }
    }
}
