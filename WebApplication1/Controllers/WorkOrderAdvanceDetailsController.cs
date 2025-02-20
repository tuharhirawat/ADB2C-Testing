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
    public class WorkOrderAdvanceDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderAdvanceDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderAdvanceDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderAdvanceDetails.ToListAsync());
        }

        // GET: WorkOrderAdvanceDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceDetails = await _context.WorkOrderAdvanceDetails
                .FirstOrDefaultAsync(m => m.WorkOrderAdvanceDetailsId == id);
            if (workOrderAdvanceDetails == null)
            {
                return NotFound();
            }

            return View(workOrderAdvanceDetails);
        }

        // GET: WorkOrderAdvanceDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderAdvanceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderAdvanceDetailsId,WorkOrderId,AdvanceAmount,AdvanceDate")] WorkOrderAdvanceDetails workOrderAdvanceDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderAdvanceDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderAdvanceDetails);
        }

        // GET: WorkOrderAdvanceDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceDetails = await _context.WorkOrderAdvanceDetails.FindAsync(id);
            if (workOrderAdvanceDetails == null)
            {
                return NotFound();
            }
            return View(workOrderAdvanceDetails);
        }

        // POST: WorkOrderAdvanceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderAdvanceDetailsId,WorkOrderId,AdvanceAmount,AdvanceDate")] WorkOrderAdvanceDetails workOrderAdvanceDetails)
        {
            if (id != workOrderAdvanceDetails.WorkOrderAdvanceDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderAdvanceDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderAdvanceDetailsExists(workOrderAdvanceDetails.WorkOrderAdvanceDetailsId))
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
            return View(workOrderAdvanceDetails);
        }

        // GET: WorkOrderAdvanceDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceDetails = await _context.WorkOrderAdvanceDetails
                .FirstOrDefaultAsync(m => m.WorkOrderAdvanceDetailsId == id);
            if (workOrderAdvanceDetails == null)
            {
                return NotFound();
            }

            return View(workOrderAdvanceDetails);
        }

        // POST: WorkOrderAdvanceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderAdvanceDetails = await _context.WorkOrderAdvanceDetails.FindAsync(id);
            if (workOrderAdvanceDetails != null)
            {
                _context.WorkOrderAdvanceDetails.Remove(workOrderAdvanceDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderAdvanceDetailsExists(int id)
        {
            return _context.WorkOrderAdvanceDetails.Any(e => e.WorkOrderAdvanceDetailsId == id);
        }
    }
}
