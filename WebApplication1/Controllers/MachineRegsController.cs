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
    public class MachineRegsController : Controller
    {
        private readonly AppDbContext _context;

        public MachineRegsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MachineRegs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MachineRegs.ToListAsync());
        }

        // GET: MachineRegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineReg = await _context.MachineRegs
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machineReg == null)
            {
                return NotFound();
            }

            return View(machineReg);
        }

        // GET: MachineRegs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MachineRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineId,MachineName,MaxPaperWidth,MaxPaperHeight,ImagePath")] MachineReg machineReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(machineReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(machineReg);
        }

        // GET: MachineRegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineReg = await _context.MachineRegs.FindAsync(id);
            if (machineReg == null)
            {
                return NotFound();
            }
            return View(machineReg);
        }

        // POST: MachineRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineId,MachineName,MaxPaperWidth,MaxPaperHeight,ImagePath")] MachineReg machineReg)
        {
            if (id != machineReg.MachineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(machineReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MachineRegExists(machineReg.MachineId))
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
            return View(machineReg);
        }

        // GET: MachineRegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var machineReg = await _context.MachineRegs
                .FirstOrDefaultAsync(m => m.MachineId == id);
            if (machineReg == null)
            {
                return NotFound();
            }

            return View(machineReg);
        }

        // POST: MachineRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var machineReg = await _context.MachineRegs.FindAsync(id);
            if (machineReg != null)
            {
                _context.MachineRegs.Remove(machineReg);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MachineRegExists(int id)
        {
            return _context.MachineRegs.Any(e => e.MachineId == id);
        }
    }
}
