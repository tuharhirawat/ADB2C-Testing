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
    public class WorkOrderAdvanceModeDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderAdvanceModeDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderAdvanceModeDetails
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WorkOrderAdvanceModeDetails.Include(w => w.WorkOrder);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WorkOrderAdvanceModeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceModeDetails = await _context.WorkOrderAdvanceModeDetails
                .Include(w => w.WorkOrder)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (workOrderAdvanceModeDetails == null)
            {
                return NotFound();
            }

            return View(workOrderAdvanceModeDetails);
        }

        // GET: WorkOrderAdvanceModeDetails/Create
        public IActionResult Create()
        {
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrderAlbumSizeDetails, "WorkOrderId", "WorkOrderId");
            return View();
        }

        // POST: WorkOrderAdvanceModeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailId,WorkOrderId,DetailInfo")] WorkOrderAdvanceModeDetails workOrderAdvanceModeDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderAdvanceModeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrderAlbumSizeDetails, "WorkOrderId", "WorkOrderId", workOrderAdvanceModeDetails.WorkOrderId);
            return View(workOrderAdvanceModeDetails);
        }

        // GET: WorkOrderAdvanceModeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceModeDetails = await _context.WorkOrderAdvanceModeDetails.FindAsync(id);
            if (workOrderAdvanceModeDetails == null)
            {
                return NotFound();
            }
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrderAlbumSizeDetails, "WorkOrderId", "WorkOrderId", workOrderAdvanceModeDetails.WorkOrderId);
            return View(workOrderAdvanceModeDetails);
        }

        // POST: WorkOrderAdvanceModeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailId,WorkOrderId,DetailInfo")] WorkOrderAdvanceModeDetails workOrderAdvanceModeDetails)
        {
            if (id != workOrderAdvanceModeDetails.DetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderAdvanceModeDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderAdvanceModeDetailsExists(workOrderAdvanceModeDetails.DetailId))
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
            ViewData["WorkOrderId"] = new SelectList(_context.WorkOrderAlbumSizeDetails, "WorkOrderId", "WorkOrderId", workOrderAdvanceModeDetails.WorkOrderId);
            return View(workOrderAdvanceModeDetails);
        }

        // GET: WorkOrderAdvanceModeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceModeDetails = await _context.WorkOrderAdvanceModeDetails
                .Include(w => w.WorkOrder)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (workOrderAdvanceModeDetails == null)
            {
                return NotFound();
            }

            return View(workOrderAdvanceModeDetails);
        }

        // POST: WorkOrderAdvanceModeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderAdvanceModeDetails = await _context.WorkOrderAdvanceModeDetails.FindAsync(id);
            if (workOrderAdvanceModeDetails != null)
            {
                _context.WorkOrderAdvanceModeDetails.Remove(workOrderAdvanceModeDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderAdvanceModeDetailsExists(int id)
        {
            return _context.WorkOrderAdvanceModeDetails.Any(e => e.DetailId == id);
        }
    }
}
