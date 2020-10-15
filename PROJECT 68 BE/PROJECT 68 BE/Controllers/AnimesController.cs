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
    public class AnimesController : ControllerBase
    {
        private readonly Anime68Context _context;

        public AnimesController(Anime68Context context)
        {
            _context = context;
        }

        // GET: api/Animes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animes>>> GetAnimes()
        {
            return await _context.Animes.ToListAsync();
        }

        // GET: api/Animes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animes>> GetAnimes(int id)
        {
            var animes = await _context.Animes.FindAsync(id);

            if (animes == null)
            {
                return NotFound();
            }

            return animes;
        }

        // PUT: api/Animes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimes(int id, Animes animes)
        {
            if (id != animes.AnimeId)
            {
                return BadRequest();
            }

            _context.Entry(animes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimesExists(id))
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

        // POST: api/Animes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Animes>> PostAnimes(Animes animes)
        {
            _context.Animes.Add(animes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimes", new { id = animes.AnimeId }, animes);
        }

        // DELETE: api/Animes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animes>> DeleteAnimes(int id)
        {
            var animes = await _context.Animes.FindAsync(id);
            if (animes == null)
            {
                return NotFound();
            }

            _context.Animes.Remove(animes);
            await _context.SaveChangesAsync();

            return animes;
        }

        private bool AnimesExists(int id)
        {
            return _context.Animes.Any(e => e.AnimeId == id);
        }
    }
}
