//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MyApp.Namespace
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AreamasterController : ControllerBase
//    {

//    }
//}



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sarat_Proj.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sarat_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreamasterController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public AreamasterController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Areamaster>>> GetAll()
        {
            return await _context.Areamasters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Areamaster>> GetById(int id)
        {
            var entity = await _context.Areamasters.FindAsync(id);
            if (entity == null)
                return NotFound();
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Areamaster>> Create(Areamaster entity)
        {
            _context.Areamasters.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.AreaId }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Areamaster entity)
        {
            if (id != entity.AreaId)
                return BadRequest();

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Areamasters.Any(e => e.AreaId == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Areamasters.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.Areamasters.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
