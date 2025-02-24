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
    public class DeliverymasterController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public DeliverymasterController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deliverymaster>>> GetAll()
        {
            return await _context.Deliverymasters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Deliverymaster>> GetById(int id)
        {
            var entity = await _context.Deliverymasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Deliverymaster>> Create(Deliverymaster entity)
        {
            _context.Deliverymasters.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Deliverytypeid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Deliverymaster entity)
        {
            if (id != entity.Deliverytypeid)
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
            var entity = await _context.Deliverymasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Deliverymasters.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Deliverymasters.Any(e => e.Deliverytypeid == id);
        }
    }
}
