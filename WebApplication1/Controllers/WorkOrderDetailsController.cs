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
    public class WorkOrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrderDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkOrderDetails.ToListAsync());
        }

        // GET: WorkOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderDetail = await _context.WorkOrderDetails
                .FirstOrDefaultAsync(m => m.WoDetailId == id);
            if (workOrderDetail == null)
            {
                return NotFound();
            }

            return View(workOrderDetail);
        }

        // GET: WorkOrderDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WoDetailId,WoStatus,DepartmentId,WoDate,WoTime,CDate,CTime,StaffId,WorkOrderId,WorkflowNo,CStatus,Description")] WorkOrderDetail workOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workOrderDetail);
        }

        // GET: WorkOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderDetail = await _context.WorkOrderDetails.FindAsync(id);
            if (workOrderDetail == null)
            {
                return NotFound();
            }
            return View(workOrderDetail);
        }

        // POST: WorkOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WoDetailId,WoStatus,DepartmentId,WoDate,WoTime,CDate,CTime,StaffId,WorkOrderId,WorkflowNo,CStatus,Description")] WorkOrderDetail workOrderDetail)
        {
            if (id != workOrderDetail.WoDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrderDetailExists(workOrderDetail.WoDetailId))
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
            return View(workOrderDetail);
        }

        // GET: WorkOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrderDetail = await _context.WorkOrderDetails
                .FirstOrDefaultAsync(m => m.WoDetailId == id);
            if (workOrderDetail == null)
            {
                return NotFound();
            }

            return View(workOrderDetail);
        }

        // POST: WorkOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrderDetail = await _context.WorkOrderDetails.FindAsync(id);
            if (workOrderDetail != null)
            {
                _context.WorkOrderDetails.Remove(workOrderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrderDetailExists(int id)
        {
            return _context.WorkOrderDetails.Any(e => e.WoDetailId == id);
        }
    }
}
