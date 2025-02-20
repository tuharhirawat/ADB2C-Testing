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
    public class WorkOrderTaxDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderTaxDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderTaxDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderTaxDetails.ToListAsync());
        }

        // GET: WorkOrderTaxDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderTaxDetails = await _context.WorkOrderTaxDetails
                .FirstOrDefaultAsync(m => m.WorkOrderTaxDetailsId == id);
            if (workOrderTaxDetails == null)
            {
                return NotFound();
            }

            return View(workOrderTaxDetails);
        }

        // GET: WorkOrderTaxDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderTaxDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderTaxDetailsId,WorkOrderId,TaxAmount,TaxType")] WorkOrderTaxDetails workOrderTaxDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderTaxDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderTaxDetails);
        }

        // GET: WorkOrderTaxDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderTaxDetails = await _context.WorkOrderTaxDetails.FindAsync(id);
            if (workOrderTaxDetails == null)
            {
                return NotFound();
            }
            return View(workOrderTaxDetails);
        }

        // POST: WorkOrderTaxDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderTaxDetailsId,WorkOrderId,TaxAmount,TaxType")] WorkOrderTaxDetails workOrderTaxDetails)
        {
            if (id != workOrderTaxDetails.WorkOrderTaxDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderTaxDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderTaxDetailsExists(workOrderTaxDetails.WorkOrderTaxDetailsId))
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
            return View(workOrderTaxDetails);
        }

        // GET: WorkOrderTaxDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderTaxDetails = await _context.WorkOrderTaxDetails
                .FirstOrDefaultAsync(m => m.WorkOrderTaxDetailsId == id);
            if (workOrderTaxDetails == null)
            {
                return NotFound();
            }

            return View(workOrderTaxDetails);
        }

        // POST: WorkOrderTaxDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderTaxDetails = await _context.WorkOrderTaxDetails.FindAsync(id);
            if (workOrderTaxDetails != null)
            {
                _context.WorkOrderTaxDetails.Remove(workOrderTaxDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderTaxDetailsExists(int id)
        {
            return _context.WorkOrderTaxDetails.Any(e => e.WorkOrderTaxDetailsId == id);
        }
    }
}
