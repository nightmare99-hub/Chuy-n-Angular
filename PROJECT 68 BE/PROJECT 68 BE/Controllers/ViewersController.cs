using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT_68_BE.Models;

namespace PROJECT_68_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewersController : ControllerBase
    {
        private readonly Anime68Context _context;

        public ViewersController(Anime68Context context)
        {
            _context = context;
        }

        // GET: api/Viewers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viewer>>> GetViewer()
        {
            return await _context.Viewer.ToListAsync();
        }

        // GET: api/Viewers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viewer>> GetViewer(int id)
        {
            var viewer = await _context.Viewer.FindAsync(id);

            if (viewer == null)
            {
                return NotFound();
            }

            return viewer;
        }

        // PUT: api/Viewers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViewer(int id, Viewer viewer)
        {
            if (id != viewer.ViewerId)
            {
                return BadRequest();
            }

            _context.Entry(viewer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewerExists(id))
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

        // POST: api/Viewers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Viewer>> PostViewer(Viewer viewer)
        {
            _context.Viewer.Add(viewer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViewer", new { id = viewer.ViewerId }, viewer);
        }

        // DELETE: api/Viewers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Viewer>> DeleteViewer(int id)
        {
            var viewer = await _context.Viewer.FindAsync(id);
            if (viewer == null)
            {
                return NotFound();
            }

            _context.Viewer.Remove(viewer);
            await _context.SaveChangesAsync();

            return viewer;
        }

        private bool ViewerExists(int id)
        {
            return _context.Viewer.Any(e => e.ViewerId == id);
        }
    }
}
