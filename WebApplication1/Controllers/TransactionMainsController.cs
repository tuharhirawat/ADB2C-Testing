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
    public class TransactionMainsController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionMainsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TransactionMains
        public async Task<IActionResult> Index()
        {
            return View(await _context.TransactionMains.ToListAsync());
        }

        // GET: TransactionMains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionMain = await _context.TransactionMains
                .FirstOrDefaultAsync(m => m.VoucherId == id);
            if (transactionMain == null)
            {
                return NotFound();
            }

            return View(transactionMain);
        }

        // GET: TransactionMains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionMains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoucherId,Voucherno,VoucherDate,BranchId,Mode,TallyId")] TransactionMain transactionMain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionMain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionMain);
        }

        // GET: TransactionMains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionMain = await _context.TransactionMains.FindAsync(id);
            if (transactionMain == null)
            {
                return NotFound();
            }
            return View(transactionMain);
        }

        // POST: TransactionMains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoucherId,Voucherno,VoucherDate,BranchId,Mode,TallyId")] TransactionMain transactionMain)
        {
            if (id != transactionMain.VoucherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transactionMain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionMainExists(transactionMain.VoucherId))
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
            return View(transactionMain);
        }

        // GET: TransactionMains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionMain = await _context.TransactionMains
                .FirstOrDefaultAsync(m => m.VoucherId == id);
            if (transactionMain == null)
            {
                return NotFound();
            }

            return View(transactionMain);
        }

        // POST: TransactionMains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionMain = await _context.TransactionMains.FindAsync(id);
            if (transactionMain != null)
            {
                _context.TransactionMains.Remove(transactionMain);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionMainExists(int id)
        {
            return _context.TransactionMains.Any(e => e.VoucherId == id);
        }
    }
}
