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
    public class WorkorderadvancemodedetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public WorkorderadvancemodedetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workorderadvancemodedetail>>> GetAll()
        {
            return await _context.Workorderadvancemodedetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workorderadvancemodedetail>> GetById(int id)
        {
            var entity = await _context.Workorderadvancemodedetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Workorderadvancemodedetail>> Create(Workorderadvancemodedetail entity)
        {
            _context.Workorderadvancemodedetails.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Workorderid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Workorderadvancemodedetail entity)
        {
            if (id != entity.Workorderid)
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
            var entity = await _context.Workorderadvancemodedetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Workorderadvancemodedetails.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Workorderadvancemodedetails.Any(e => e.Workorderid == id);
        }
    }
}
