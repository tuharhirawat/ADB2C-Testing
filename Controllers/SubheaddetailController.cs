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
    public class SubheaddetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public SubheaddetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subheaddetail>>> GetAll()
        {
            return await _context.Subheaddetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subheaddetail>> GetById(int id)
        {
            var entity = await _context.Subheaddetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Subheaddetail>> Create(Subheaddetail entity)
        {
            _context.Subheaddetails.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Subheadid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Subheaddetail entity)
        {
            if (id != entity.Subheadid)
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
            var entity = await _context.Subheaddetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Subheaddetails.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Subheaddetails.Any(e => e.Subheadid == id);
        }
    }
}
