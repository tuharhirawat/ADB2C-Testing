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
    public class WorktypeController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public WorktypeController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Worktype>>> GetAll()
        {
            return await _context.Worktypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Worktype>> GetById(int id)
        {
            var entity = await _context.Worktypes.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Worktype>> Create(Worktype entity)
        {
            _context.Worktypes.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Worktypeid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Worktype entity)
        {
            if (id != entity.Worktypeid)
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
            var entity = await _context.Worktypes.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Worktypes.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Worktypes.Any(e => e.Worktypeid == id);
        }
    }
}
