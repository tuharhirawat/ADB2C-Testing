//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MyApp.Namespace
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BillworkdetailController : ControllerBase
//    {

//    }
//}



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sarat_Proj.Models; // Replace with your actual namespace

namespace Sarat_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillworkdetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public BillworkdetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        // ✅ GET all records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billworkdetail>>> GetAll()
        {
            return await _context.Billworkdetails.ToListAsync();
        }

        // ✅ GET a single record by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Billworkdetail>> GetById(int id)
        {
            var entity = await _context.Billworkdetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        // ✅ POST - Add new record
        [HttpPost]
        public async Task<ActionResult<Billworkdetail>> Create(Billworkdetail entity)
        {
            _context.Billworkdetails.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Billid }, entity);
        }

        // ✅ PUT - Update record
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Billworkdetail entity)
        {
            if (id != entity.Billid)
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
            var entity = await _context.Billworkdetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Billworkdetails.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Billworkdetails.Any(e => e.Billid == id);
        }
    }
}
