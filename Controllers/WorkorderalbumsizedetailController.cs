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
    public class WorkorderalbumsizedetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public WorkorderalbumsizedetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workorderalbumsizedetail>>> GetAll()
        {
            return await _context.Workorderalbumsizedetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workorderalbumsizedetail>> GetById(int id)
        {
            var entity = await _context.Workorderalbumsizedetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Workorderalbumsizedetail>> Create(Workorderalbumsizedetail entity)
        {
            _context.Workorderalbumsizedetails.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Workorderid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Workorderalbumsizedetail entity)
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
            var entity = await _context.Workorderalbumsizedetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Workorderalbumsizedetails.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Workorderalbumsizedetails.Any(e => e.Workorderid == id);
        }
    }
}
