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
    public class DepartmentmasterController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public DepartmentmasterController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departmentmaster>>> GetAll()
        {
            return await _context.Departmentmasters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departmentmaster>> GetById(int id)
        {
            var entity = await _context.Departmentmasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Departmentmaster>> Create(Departmentmaster entity)
        {
            _context.Departmentmasters.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Departmentid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Departmentmaster entity)
        {
            if (id != entity.Departmentid)
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
            var entity = await _context.Departmentmasters.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Departmentmasters.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Departmentmasters.Any(e => e.Departmentid == id);
        }
    }
}
