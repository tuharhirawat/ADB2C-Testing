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
    public class CustomerRegsController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerRegsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CustomerRegs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerRegs.ToListAsync());
        }

        // GET: CustomerRegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerReg = await _context.CustomerRegs
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerReg == null)
            {
                return NotFound();
            }

            return View(customerReg);
        }

        // GET: CustomerRegs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerRegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,StudioName,Address1,Address2,Address3,State,PhoneNo,Mobile,Email,Remarks,CategoryId,RateType,StaffId,Discount,Mode,Area,RegionId,TypeId,CustomerTypeId,BranchId,WhatsappNo")] CustomerReg customerReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerReg);
        }

        // GET: CustomerRegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerReg = await _context.CustomerRegs.FindAsync(id);
            if (customerReg == null)
            {
                return NotFound();
            }
            return View(customerReg);
        }

        // POST: CustomerRegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,StudioName,Address1,Address2,Address3,State,PhoneNo,Mobile,Email,Remarks,CategoryId,RateType,StaffId,Discount,Mode,Area,RegionId,TypeId,CustomerTypeId,BranchId,WhatsappNo")] CustomerReg customerReg)
        {
            if (id != customerReg.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerRegExists(customerReg.CustomerId))
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
            return View(customerReg);
        }

        // GET: CustomerRegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerReg = await _context.CustomerRegs
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerReg == null)
            {
                return NotFound();
            }

            return View(customerReg);
        }

        // POST: CustomerRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerReg = await _context.CustomerRegs.FindAsync(id);
            if (customerReg != null)
            {
                _context.CustomerRegs.Remove(customerReg);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerRegExists(int id)
        {
            return _context.CustomerRegs.Any(e => e.CustomerId == id);
        }
    }
}
