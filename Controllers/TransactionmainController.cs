using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sarat_Proj.Models;
using Microsoft.AspNetCore.Authorization;

namespace Sarat_Proj.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TransactionmainController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public TransactionmainController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactionmain>>> GetAll()
        {
            return await _context.Transactionmains.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transactionmain>> GetById(int id)
        {
            var entity = await _context.Transactionmains.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Transactionmain>> Create(Transactionmain entity)
        {
            _context.Transactionmains.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Voucherid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Transactionmain entity)
        {
            if (id != entity.Voucherid)
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
            var entity = await _context.Transactionmains.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Transactionmains.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Transactionmains.Any(e => e.Voucherid == id);
        }
    }
}
