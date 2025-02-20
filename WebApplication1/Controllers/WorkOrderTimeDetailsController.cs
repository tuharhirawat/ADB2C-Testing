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
    public class WorkOrderTimeDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderTimeDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderTimeDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderTimeDetails.ToListAsync());
        }

        // GET: WorkOrderTimeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderTimeDetails = await _context.WorkOrderTimeDetails
                .FirstOrDefaultAsync(m => m.WorkOrderTimeDetailsId == id);
            if (workOrderTimeDetails == null)
            {
                return NotFound();
            }

            return View(workOrderTimeDetails);
        }

        // GET: WorkOrderTimeDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderTimeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderTimeDetailsId,WorkOrderId,StartTime,EndTime")] WorkOrderTimeDetails workOrderTimeDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderTimeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderTimeDetails);
        }

        // GET: WorkOrderTimeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderTimeDetails = await _context.WorkOrderTimeDetails.FindAsync(id);
            if (workOrderTimeDetails == null)
            {
                return NotFound();
            }
            return View(workOrderTimeDetails);
        }

        // POST: WorkOrderTimeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderTimeDetailsId,WorkOrderId,StartTime,EndTime")] WorkOrderTimeDetails workOrderTimeDetails)
        {
            if (id != workOrderTimeDetails.WorkOrderTimeDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderTimeDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderTimeDetailsExists(workOrderTimeDetails.WorkOrderTimeDetailsId))
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
            return View(workOrderTimeDetails);
        }

        // GET: WorkOrderTimeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderTimeDetails = await _context.WorkOrderTimeDetails
                .FirstOrDefaultAsync(m => m.WorkOrderTimeDetailsId == id);
            if (workOrderTimeDetails == null)
            {
                return NotFound();
            }

            return View(workOrderTimeDetails);
        }

        // POST: WorkOrderTimeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderTimeDetails = await _context.WorkOrderTimeDetails.FindAsync(id);
            if (workOrderTimeDetails != null)
            {
                _context.WorkOrderTimeDetails.Remove(workOrderTimeDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderTimeDetailsExists(int id)
        {
            return _context.WorkOrderTimeDetails.Any(e => e.WorkOrderTimeDetailsId == id);
        }
    }
}
