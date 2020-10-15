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
    public class AnimeTypesController : ControllerBase
    {
        private readonly Anime68Context _context;

        public AnimeTypesController(Anime68Context context)
        {
            _context = context;
        }

        // GET: api/AnimeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeType>>> GetAnimeType()
        {
            return await _context.AnimeType.ToListAsync();
        }

        // GET: api/AnimeTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeType>> GetAnimeType(int id)
        {
            var animeType = await _context.AnimeType.FindAsync(id);

            if (animeType == null)
            {
                return NotFound();
            }

            return animeType;
        }

        // PUT: api/AnimeTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeType(int id, AnimeType animeType)
        {
            if (id != animeType.AnimeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(animeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeTypeExists(id))
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

        // POST: api/AnimeTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnimeType>> PostAnimeType(AnimeType animeType)
        {
            _context.AnimeType.Add(animeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeType", new { id = animeType.AnimeTypeId }, animeType);
        }

        // DELETE: api/AnimeTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimeType>> DeleteAnimeType(int id)
        {
            var animeType = await _context.AnimeType.FindAsync(id);
            if (animeType == null)
            {
                return NotFound();
            }

            _context.AnimeType.Remove(animeType);
            await _context.SaveChangesAsync();

            return animeType;
        }

        private bool AnimeTypeExists(int id)
        {
            return _context.AnimeType.Any(e => e.AnimeTypeId == id);
        }
    }
}
