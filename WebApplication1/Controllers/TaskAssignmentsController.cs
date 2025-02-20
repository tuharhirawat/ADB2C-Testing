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
    public class TaskAssignmentsController : Controller
    {
        private readonly AppDbContext _context;

        public TaskAssignmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TaskAssignments
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskAssignment.ToListAsync());
        }

        // GET: TaskAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAssignment = await _context.TaskAssignment
                .FirstOrDefaultAsync(m => m.TaskAssignmentId == id);
            if (taskAssignment == null)
            {
                return NotFound();
            }

            return View(taskAssignment);
        }

        // GET: TaskAssignments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskAssignmentId,TaskName,AssignedTo,AssignedDate")] TaskAssignment taskAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskAssignment);
        }

        // GET: TaskAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAssignment = await _context.TaskAssignment.FindAsync(id);
            if (taskAssignment == null)
            {
                return NotFound();
            }
            return View(taskAssignment);
        }

        // POST: TaskAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskAssignmentId,TaskName,AssignedTo,AssignedDate")] TaskAssignment taskAssignment)
        {
            if (id != taskAssignment.TaskAssignmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskAssignmentExists(taskAssignment.TaskAssignmentId))
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
            return View(taskAssignment);
        }

        // GET: TaskAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskAssignment = await _context.TaskAssignment
                .FirstOrDefaultAsync(m => m.TaskAssignmentId == id);
            if (taskAssignment == null)
            {
                return NotFound();
            }

            return View(taskAssignment);
        }

        // POST: TaskAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskAssignment = await _context.TaskAssignment.FindAsync(id);
            if (taskAssignment != null)
            {
                _context.TaskAssignment.Remove(taskAssignment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskAssignmentExists(int id)
        {
            return _context.TaskAssignment.Any(e => e.TaskAssignmentId == id);
        }
    }
}
