using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sarat_Proj.Models;
using Microsoft.AspNetCore.Authorization;

namespace Sarat_Proj.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AccountheadmasterController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public AccountheadmasterController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accountheadmaster>>> GetAll()
        {
            return await _context.Accountheadmasters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Accountheadmaster>> GetById(int id)
        {
            var entity = await _context.Accountheadmasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Accountheadmaster>> Create(Accountheadmaster entity)
        {
            _context.Accountheadmasters.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Accountheadid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Accountheadmaster entity)
        {
            if (id != entity.Accountheadid)
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
            var entity = await _context.Accountheadmasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Accountheadmasters.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Accountheadmasters.Any(e => e.Accountheadid == id);
        }
    }
}
