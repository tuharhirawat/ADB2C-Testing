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
    public class ReceiptMastersController : Controller
    {
        private readonly AppDbContext _context;

        public ReceiptMastersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ReceiptMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReceiptMasters.ToListAsync());
        }

        // GET: ReceiptMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptMaster = await _context.ReceiptMasters
                .FirstOrDefaultAsync(m => m.ReceiptId == id);
            if (receiptMaster == null)
            {
                return NotFound();
            }

            return View(receiptMaster);
        }

        // GET: ReceiptMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReceiptMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceiptId,ReceiptNo,VoucherId")] ReceiptMaster receiptMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiptMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receiptMaster);
        }

        // GET: ReceiptMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptMaster = await _context.ReceiptMasters.FindAsync(id);
            if (receiptMaster == null)
            {
                return NotFound();
            }
            return View(receiptMaster);
        }

        // POST: ReceiptMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceiptId,ReceiptNo,VoucherId")] ReceiptMaster receiptMaster)
        {
            if (id != receiptMaster.ReceiptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptMasterExists(receiptMaster.ReceiptId))
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
            return View(receiptMaster);
        }

        // GET: ReceiptMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptMaster = await _context.ReceiptMasters
                .FirstOrDefaultAsync(m => m.ReceiptId == id);
            if (receiptMaster == null)
            {
                return NotFound();
            }

            return View(receiptMaster);
        }

        // POST: ReceiptMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receiptMaster = await _context.ReceiptMasters.FindAsync(id);
            if (receiptMaster != null)
            {
                _context.ReceiptMasters.Remove(receiptMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptMasterExists(int id)
        {
            return _context.ReceiptMasters.Any(e => e.ReceiptId == id);
        }
    }
}
