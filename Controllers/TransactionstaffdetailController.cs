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
    public class TransactionstaffdetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public TransactionstaffdetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transactionstaffdetail>>> GetAll()
        {
            return await _context.Transactionstaffdetails.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transactionstaffdetail>> GetById(int id)
        {
            var entity = await _context.Transactionstaffdetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }

        [HttpPost]
        public async Task<ActionResult<Transactionstaffdetail>> Create(Transactionstaffdetail entity)
        {
            _context.Transactionstaffdetails.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Transactionstaffid }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Transactionstaffdetail entity)
        {
            if (id != entity.Transactionstaffid)
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
            var entity = await _context.Transactionstaffdetails.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Transactionstaffdetails.Remove(entity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool EntityExists(int id)
        {
            return _context.Transactionstaffdetails.Any(e => e.Transactionstaffid == id);
        }
    }
}
