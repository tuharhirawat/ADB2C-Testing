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
    public class WorkOrderAlbumSizeDetails1Controller : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderAlbumSizeDetails1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderAlbumSizeDetails1
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderAlbumSizeDetails.ToListAsync());
        }

        // GET: WorkOrderAlbumSizeDetails1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAlbumSizeDetails1 = await _context.WorkOrderAlbumSizeDetails
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrderAlbumSizeDetails1 == null)
            {
                return NotFound();
            }

            return View(workOrderAlbumSizeDetails1);
        }

        // GET: WorkOrderAlbumSizeDetails1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderAlbumSizeDetails1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderId,Description")] WorkOrderAlbumSizeDetails1 workOrderAlbumSizeDetails1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderAlbumSizeDetails1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderAlbumSizeDetails1);
        }

        // GET: WorkOrderAlbumSizeDetails1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAlbumSizeDetails1 = await _context.WorkOrderAlbumSizeDetails.FindAsync(id);
            if (workOrderAlbumSizeDetails1 == null)
            {
                return NotFound();
            }
            return View(workOrderAlbumSizeDetails1);
        }

        // POST: WorkOrderAlbumSizeDetails1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderId,Description")] WorkOrderAlbumSizeDetails1 workOrderAlbumSizeDetails1)
        {
            if (id != workOrderAlbumSizeDetails1.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderAlbumSizeDetails1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderAlbumSizeDetails1Exists(workOrderAlbumSizeDetails1.WorkOrderId))
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
            return View(workOrderAlbumSizeDetails1);
        }

        // GET: WorkOrderAlbumSizeDetails1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderAlbumSizeDetails1 = await _context.WorkOrderAlbumSizeDetails
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrderAlbumSizeDetails1 == null)
            {
                return NotFound();
            }

            return View(workOrderAlbumSizeDetails1);
        }

        // POST: WorkOrderAlbumSizeDetails1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderAlbumSizeDetails1 = await _context.WorkOrderAlbumSizeDetails.FindAsync(id);
            if (workOrderAlbumSizeDetails1 != null)
            {
                _context.WorkOrderAlbumSizeDetails.Remove(workOrderAlbumSizeDetails1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderAlbumSizeDetails1Exists(int id)
        {
            return _context.WorkOrderAlbumSizeDetails.Any(e => e.WorkOrderId == id);
        }
    }
}
