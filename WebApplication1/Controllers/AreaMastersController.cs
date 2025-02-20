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
    public class AreaMastersController : Controller
    {
        private readonly AppDbContext _context;

        public AreaMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AreaMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.AreaMasters.ToListAsync());
        }

        // GET: AreaMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaMaster = await _context.AreaMasters
                .FirstOrDefaultAsync(m => m.AreaId == id);
            if (areaMaster == null)
            {
                return NotFound();
            }

            return View(areaMaster);
        }

        // GET: AreaMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaId,AreaName")] AreaMaster areaMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaMaster);
        }

        // GET: AreaMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaMaster = await _context.AreaMasters.FindAsync(id);
            if (areaMaster == null)
            {
                return NotFound();
            }
            return View(areaMaster);
        }

        // POST: AreaMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaId,AreaName")] AreaMaster areaMaster)
        {
            if (id != areaMaster.AreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaMasterExists(areaMaster.AreaId))
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
            return View(areaMaster);
        }

        // GET: AreaMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaMaster = await _context.AreaMasters
                .FirstOrDefaultAsync(m => m.AreaId == id);
            if (areaMaster == null)
            {
                return NotFound();
            }

            return View(areaMaster);
        }

        // POST: AreaMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaMaster = await _context.AreaMasters.FindAsync(id);
            if (areaMaster != null)
            {
                _context.AreaMasters.Remove(areaMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaMasterExists(int id)
        {
            return _context.AreaMasters.Any(e => e.AreaId == id);
        }
    }
}
