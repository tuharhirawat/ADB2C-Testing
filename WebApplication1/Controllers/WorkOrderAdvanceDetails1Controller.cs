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
    public class WorkOrderAdvanceDetails1Controller : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderAdvanceDetails1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderAdvanceDetails1
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderAdvanceDetails1.ToListAsync());
        }

        // GET: WorkOrderAdvanceDetails1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceDetails1 = await _context.WorkOrderAdvanceDetails1
                .FirstOrDefaultAsync(m => m.WorkOrderAdvanceDetailsId == id);
            if (workOrderAdvanceDetails1 == null)
            {
                return NotFound();
            }

            return View(workOrderAdvanceDetails1);
        }

        // GET: WorkOrderAdvanceDetails1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderAdvanceDetails1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderAdvanceDetailsId,WorkOrderId,AdvanceAmount,PaymentDate")] WorkOrderAdvanceDetails1 workOrderAdvanceDetails1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderAdvanceDetails1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderAdvanceDetails1);
        }

        // GET: WorkOrderAdvanceDetails1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceDetails1 = await _context.WorkOrderAdvanceDetails1.FindAsync(id);
            if (workOrderAdvanceDetails1 == null)
            {
                return NotFound();
            }
            return View(workOrderAdvanceDetails1);
        }

        // POST: WorkOrderAdvanceDetails1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderAdvanceDetailsId,WorkOrderId,AdvanceAmount,PaymentDate")] WorkOrderAdvanceDetails1 workOrderAdvanceDetails1)
        {
            if (id != workOrderAdvanceDetails1.WorkOrderAdvanceDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderAdvanceDetails1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderAdvanceDetails1Exists(workOrderAdvanceDetails1.WorkOrderAdvanceDetailsId))
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
            return View(workOrderAdvanceDetails1);
        }

        // GET: WorkOrderAdvanceDetails1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAdvanceDetails1 = await _context.WorkOrderAdvanceDetails1
                .FirstOrDefaultAsync(m => m.WorkOrderAdvanceDetailsId == id);
            if (workOrderAdvanceDetails1 == null)
            {
                return NotFound();
            }

            return View(workOrderAdvanceDetails1);
        }

        // POST: WorkOrderAdvanceDetails1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderAdvanceDetails1 = await _context.WorkOrderAdvanceDetails1.FindAsync(id);
            if (workOrderAdvanceDetails1 != null)
            {
                _context.WorkOrderAdvanceDetails1.Remove(workOrderAdvanceDetails1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderAdvanceDetails1Exists(int id)
        {
            return _context.WorkOrderAdvanceDetails1.Any(e => e.WorkOrderAdvanceDetailsId == id);
        }
    }
}
