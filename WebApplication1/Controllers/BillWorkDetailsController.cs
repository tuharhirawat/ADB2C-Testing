using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BillWorkDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public BillWorkDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BillWorkDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.BillWorkDetails.ToListAsync());
        }

        // GET: BillWorkDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billWorkDetails = await _context.BillWorkDetails
                .FirstOrDefaultAsync(m => m.BillWorkDetailId == id);
            if (billWorkDetails == null)
            {
                return NotFound();
            }

            return View(billWorkDetails);
        }

        // GET: BillWorkDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BillWorkDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillWorkDetailId,WorkDescription,Amount")] BillWorkDetails billWorkDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billWorkDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billWorkDetails);
        }

        // GET: BillWorkDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billWorkDetails = await _context.BillWorkDetails.FindAsync(id);
            if (billWorkDetails == null)
            {
                return NotFound();
            }
            return View(billWorkDetails);
        }

        // POST: BillWorkDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillWorkDetailId,WorkDescription,Amount")] BillWorkDetails billWorkDetails)
        {
            if (id != billWorkDetails.BillWorkDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billWorkDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillWorkDetailsExists(billWorkDetails.BillWorkDetailId))
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
            return View(billWorkDetails);
        }

        // GET: BillWorkDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billWorkDetails = await _context.BillWorkDetails
                .FirstOrDefaultAsync(m => m.BillWorkDetailId == id);
            if (billWorkDetails == null)
            {
                return NotFound();
            }

            return View(billWorkDetails);
        }

        // POST: BillWorkDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billWorkDetails = await _context.BillWorkDetails.FindAsync(id);
            if (billWorkDetails != null)
            {
                _context.BillWorkDetails.Remove(billWorkDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillWorkDetailsExists(int id)
        {
            return _context.BillWorkDetails.Any(e => e.BillWorkDetailId == id);
        }
    }
}
