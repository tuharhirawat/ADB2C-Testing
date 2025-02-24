using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sarat_Proj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sarat_Proj.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CustomerregController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public CustomerregController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customerreg>>> GetAll()
        {
            return await _context.Customerregs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customerreg>> GetById(int id)
        {
            var entity = await _context.Customerregs.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Customerreg>> Create(Customerreg entity)
        {
            _context.Customerregs.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Customerid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customerreg entity)
        {
            if (id != entity.Customerid)
            {
                return BadRequest();
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Customerregs.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Customerregs.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Customerregs.Any(e => e.Customerid == id);
        }
    }
}
