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
    public class WorkorderdetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public WorkorderdetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workorderdetail>>> GetAll()
        {
            return await _context.Workorderdetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workorderdetail>> GetById(int id)
        {
            var entity = await _context.Workorderdetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Workorderdetail>> Create(Workorderdetail entity)
        {
            _context.Workorderdetails.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Wodetailid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Workorderdetail entity)
        {
            if (id != entity.Wodetailid)
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
            var entity = await _context.Workorderdetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Workorderdetails.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Workorderdetails.Any(e => e.Wodetailid == id);

        }
    }
}
