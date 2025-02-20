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
    public class DeliveryMastersController : Controller
    {
        private readonly AppDbContext _context;

        public DeliveryMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeliveryMasters.ToListAsync());
        }

        // GET: DeliveryMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryMaster = await _context.DeliveryMasters
                .FirstOrDefaultAsync(m => m.DeliveryTypeId == id);
            if (deliveryMaster == null)
            {
                return NotFound();
            }

            return View(deliveryMaster);
        }

        // GET: DeliveryMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeliveryMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryTypeId,DeliveryName,Remarks")] DeliveryMaster deliveryMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryMaster);
        }

        // GET: DeliveryMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryMaster = await _context.DeliveryMasters.FindAsync(id);
            if (deliveryMaster == null)
            {
                return NotFound();
            }
            return View(deliveryMaster);
        }

        // POST: DeliveryMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryTypeId,DeliveryName,Remarks")] DeliveryMaster deliveryMaster)
        {
            if (id != deliveryMaster.DeliveryTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryMasterExists(deliveryMaster.DeliveryTypeId))
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
            return View(deliveryMaster);
        }

        // GET: DeliveryMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryMaster = await _context.DeliveryMasters
                .FirstOrDefaultAsync(m => m.DeliveryTypeId == id);
            if (deliveryMaster == null)
            {
                return NotFound();
            }

            return View(deliveryMaster);
        }

        // POST: DeliveryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryMaster = await _context.DeliveryMasters.FindAsync(id);
            if (deliveryMaster != null)
            {
                _context.DeliveryMasters.Remove(deliveryMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryMasterExists(int id)
        {
            return _context.DeliveryMasters.Any(e => e.DeliveryTypeId == id);
        }
    }
}
