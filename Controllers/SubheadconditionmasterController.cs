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
    public class SubheadconditionmasterController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public SubheadconditionmasterController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subheadconditionmaster>>> GetAll()
        {
            return await _context.Subheadconditionmasters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subheadconditionmaster>> GetById(int id)
        {
            var entity = await _context.Subheadconditionmasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Subheadconditionmaster>> Create(Subheadconditionmaster entity)
        {
            _context.Subheadconditionmasters.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Subheadconditionmaster entity)
        {
            if (id != entity.Id)
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
            var entity = await _context.Subheadconditionmasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Subheadconditionmasters.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Subheadconditionmasters.Any(e => e.Id == id);
        }
    }
}
