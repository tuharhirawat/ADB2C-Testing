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
    public class SubHeadConditionMastersController : Controller
    {
        private readonly AppDbContext _context;

        public SubHeadConditionMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SubHeadConditionMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubHeadConditionMasters.ToListAsync());
        }

        // GET: SubHeadConditionMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subHeadConditionMaster = await _context.SubHeadConditionMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subHeadConditionMaster == null)
            {
                return NotFound();
            }

            return View(subHeadConditionMaster);
        }

        // GET: SubHeadConditionMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubHeadConditionMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MainHeadId,MaxPage,ExtraRate,Mode")] SubHeadConditionMaster subHeadConditionMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subHeadConditionMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subHeadConditionMaster);
        }

        // GET: SubHeadConditionMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subHeadConditionMaster = await _context.SubHeadConditionMasters.FindAsync(id);
            if (subHeadConditionMaster == null)
            {
                return NotFound();
            }
            return View(subHeadConditionMaster);
        }

        // POST: SubHeadConditionMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MainHeadId,MaxPage,ExtraRate,Mode")] SubHeadConditionMaster subHeadConditionMaster)
        {
            if (id != subHeadConditionMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subHeadConditionMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubHeadConditionMasterExists(subHeadConditionMaster.Id))
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
            return View(subHeadConditionMaster);
        }

        // GET: SubHeadConditionMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subHeadConditionMaster = await _context.SubHeadConditionMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subHeadConditionMaster == null)
            {
                return NotFound();
            }

            return View(subHeadConditionMaster);
        }

        // POST: SubHeadConditionMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subHeadConditionMaster = await _context.SubHeadConditionMasters.FindAsync(id);
            if (subHeadConditionMaster != null)
            {
                _context.SubHeadConditionMasters.Remove(subHeadConditionMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubHeadConditionMasterExists(int id)
        {
            return _context.SubHeadConditionMasters.Any(e => e.Id == id);
        }
    }
}
