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
    public class MainHeadRegsController : Controller
    {
        private readonly AppDbContext _context;

        public MainHeadRegsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MainHeadRegs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainHeadRegs.ToListAsync());
        }

        // GET: MainHeadRegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainHeadReg = await _context.MainHeadRegs
                .FirstOrDefaultAsync(m => m.MainHeadId == id);
            if (mainHeadReg == null)
            {
                return NotFound();
            }

            return View(mainHeadReg);
        }

        // GET: MainHeadRegs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainHeadRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainHeadId,HeadName,Remarks,Discount,Custom,RemarkStatus")] MainHeadReg mainHeadReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainHeadReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainHeadReg);
        }

        // GET: MainHeadRegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainHeadReg = await _context.MainHeadRegs.FindAsync(id);
            if (mainHeadReg == null)
            {
                return NotFound();
            }
            return View(mainHeadReg);
        }

        // POST: MainHeadRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainHeadId,HeadName,Remarks,Discount,Custom,RemarkStatus")] MainHeadReg mainHeadReg)
        {
            if (id != mainHeadReg.MainHeadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainHeadReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainHeadRegExists(mainHeadReg.MainHeadId))
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
            return View(mainHeadReg);
        }

        // GET: MainHeadRegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainHeadReg = await _context.MainHeadRegs
                .FirstOrDefaultAsync(m => m.MainHeadId == id);
            if (mainHeadReg == null)
            {
                return NotFound();
            }

            return View(mainHeadReg);
        }

        // POST: MainHeadRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainHeadReg = await _context.MainHeadRegs.FindAsync(id);
            if (mainHeadReg != null)
            {
                _context.MainHeadRegs.Remove(mainHeadReg);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainHeadRegExists(int id)
        {
            return _context.MainHeadRegs.Any(e => e.MainHeadId == id);
        }
    }
}
