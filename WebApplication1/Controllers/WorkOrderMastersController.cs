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
    public class WorkOrderMastersController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderMasters.ToListAsync());
        }

        // GET: WorkOrderMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderMaster = await _context.WorkOrderMasters
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrderMaster == null)
            {
                return NotFound();
            }

            return View(workOrderMaster);
        }

        // GET: WorkOrderMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderId,WorkOrderNo,CustomerId,WorkTypeId,NoOfPhoto,WDate,WTime,DDate,DTime,WorkStatus,Type,Description,Remarks,DeliveryTypeId,CStatus,Id,MachineId,NoOfCopies,StaffId,WNo,SeId,OrderVia,BranchId")] WorkOrderMaster workOrderMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderMaster);
        }

        // GET: WorkOrderMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderMaster = await _context.WorkOrderMasters.FindAsync(id);
            if (workOrderMaster == null)
            {
                return NotFound();
            }
            return View(workOrderMaster);
        }

        // POST: WorkOrderMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderId,WorkOrderNo,CustomerId,WorkTypeId,NoOfPhoto,WDate,WTime,DDate,DTime,WorkStatus,Type,Description,Remarks,DeliveryTypeId,CStatus,Id,MachineId,NoOfCopies,StaffId,WNo,SeId,OrderVia,BranchId")] WorkOrderMaster workOrderMaster)
        {
            if (id != workOrderMaster.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderMasterExists(workOrderMaster.WorkOrderId))
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
            return View(workOrderMaster);
        }

        // GET: WorkOrderMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderMaster = await _context.WorkOrderMasters
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrderMaster == null)
            {
                return NotFound();
            }

            return View(workOrderMaster);
        }

        // POST: WorkOrderMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderMaster = await _context.WorkOrderMasters.FindAsync(id);
            if (workOrderMaster != null)
            {
                _context.WorkOrderMasters.Remove(workOrderMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderMasterExists(int id)
        {
            return _context.WorkOrderMasters.Any(e => e.WorkOrderId == id);
        }
    }
}
