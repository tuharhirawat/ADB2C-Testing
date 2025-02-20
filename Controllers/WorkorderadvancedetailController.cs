//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MyApp.Namespace
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class WorkorderadvancedetailController : ControllerBase
//    {
//    }
//}
















using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sarat_Proj.Models;

namespace Sarat_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkorderadvancedetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public WorkorderadvancedetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        // ✅ GET all records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workorderadvancedetail>>> GetAll()
        {
            return await _context.Workorderadvancedetails.ToListAsync();
        }

        // ✅ GET a single record by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Workorderadvancedetail>> GetById(int id)
        {
            var entity = await _context.Workorderadvancedetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // ✅ POST - Add new record
        [HttpPost]
        public async Task<ActionResult<Workorderadvancedetail>> Create(Workorderadvancedetail entity)
        {
            _context.Workorderadvancedetails.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Referencetypeid }, entity);
        }

        // ✅ PUT - Update record
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Workorderadvancedetail entity)
        {
            if (id != entity.Referencetypeid)
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

        // ✅ DELETE - Remove record
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Workorderadvancedetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Workorderadvancedetails.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Workorderadvancedetails.Any(e => e.Referencetypeid == id);
        }
    }
}
