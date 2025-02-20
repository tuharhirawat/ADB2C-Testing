//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace MyApp.Namespace
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AlbumsizedetailController : ControllerBase
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
    public class AlbumsizedetailController : ControllerBase
    {
        private readonly SaratDatabaseContext _context;

        public AlbumsizedetailController(SaratDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Albumsizedetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Albumsizedetail>>> GetAlbumsizedetails()
        {
            return await _context.Albumsizedetails.ToListAsync();
        }

        // GET: api/Albumsizedetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Albumsizedetail>> GetAlbumsizedetail(int id)
        {
            var albumsizedetail = await _context.Albumsizedetails.FindAsync(id);
            if (albumsizedetail == null)
            {
                return NotFound();
            }
            return albumsizedetail;
        }

        // POST: api/Albumsizedetail
        [HttpPost]
        public async Task<ActionResult<Albumsizedetail>> PostAlbumsizedetail(Albumsizedetail albumsizedetail)
        {
            _context.Albumsizedetails.Add(albumsizedetail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlbumsizedetail), new { id = albumsizedetail.Sizeid }, albumsizedetail);
        }

        // PUT: api/Albumsizedetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbumsizedetail(int id, Albumsizedetail albumsizedetail)
        {
            if (id != albumsizedetail.Sizeid)
            {
                return BadRequest();
            }
            _context.Entry(albumsizedetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Albumsizedetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbumsizedetail(int id)
        {
            var albumsizedetail = await _context.Albumsizedetails.FindAsync(id);
            if (albumsizedetail == null)
            {
                return NotFound();
            }
            _context.Albumsizedetails.Remove(albumsizedetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
