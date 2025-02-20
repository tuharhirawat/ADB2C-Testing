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
    public class UpdateSubHeadDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public UpdateSubHeadDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UpdateSubHeadDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.UpdateSubHeadDetails.ToListAsync());
        }

        // GET: UpdateSubHeadDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updateSubHeadDetail = await _context.UpdateSubHeadDetails
                .FirstOrDefaultAsync(m => m.UpdateSubHeadDetailId == id);
            if (updateSubHeadDetail == null)
            {
                return NotFound();
            }

            return View(updateSubHeadDetail);
        }

        // GET: UpdateSubHeadDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UpdateSubHeadDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UpdateSubHeadDetailId,SubHeadName,Amount")] UpdateSubHeadDetail updateSubHeadDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(updateSubHeadDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(updateSubHeadDetail);
        }

        // GET: UpdateSubHeadDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updateSubHeadDetail = await _context.UpdateSubHeadDetails.FindAsync(id);
            if (updateSubHeadDetail == null)
            {
                return NotFound();
            }
            return View(updateSubHeadDetail);
        }

        // POST: UpdateSubHeadDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UpdateSubHeadDetailId,SubHeadName,Amount")] UpdateSubHeadDetail updateSubHeadDetail)
        {
            if (id != updateSubHeadDetail.UpdateSubHeadDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updateSubHeadDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpdateSubHeadDetailExists(updateSubHeadDetail.UpdateSubHeadDetailId))
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
            return View(updateSubHeadDetail);
        }

        // GET: UpdateSubHeadDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var updateSubHeadDetail = await _context.UpdateSubHeadDetails
                .FirstOrDefaultAsync(m => m.UpdateSubHeadDetailId == id);
            if (updateSubHeadDetail == null)
            {
                return NotFound();
            }

            return View(updateSubHeadDetail);
        }

        // POST: UpdateSubHeadDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var updateSubHeadDetail = await _context.UpdateSubHeadDetails.FindAsync(id);
            if (updateSubHeadDetail != null)
            {
                _context.UpdateSubHeadDetails.Remove(updateSubHeadDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpdateSubHeadDetailExists(int id)
        {
            return _context.UpdateSubHeadDetails.Any(e => e.UpdateSubHeadDetailId == id);
        }
    }
}
