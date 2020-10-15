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
    public class AirDatesController : ControllerBase
    {
        private readonly Anime68Context _context;

        public AirDatesController(Anime68Context context)
        {
            _context = context;
        }

        // GET: api/AirDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirDate>>> GetAirDate()
        {
            return await _context.AirDate.ToListAsync();
        }

        // GET: api/AirDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirDate>> GetAirDate(int id)
        {
            var airDate = await _context.AirDate.FindAsync(id);

            if (airDate == null)
            {
                return NotFound();
            }

            return airDate;
        }

        // PUT: api/AirDates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirDate(int id, AirDate airDate)
        {
            if (id != airDate.AirDateId)
            {
                return BadRequest();
            }

            _context.Entry(airDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirDateExists(id))
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

        // POST: api/AirDates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AirDate>> PostAirDate(AirDate airDate)
        {
            _context.AirDate.Add(airDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirDate", new { id = airDate.AirDateId }, airDate);
        }

        // DELETE: api/AirDates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AirDate>> DeleteAirDate(int id)
        {
            var airDate = await _context.AirDate.FindAsync(id);
            if (airDate == null)
            {
                return NotFound();
            }

            _context.AirDate.Remove(airDate);
            await _context.SaveChangesAsync();

            return airDate;
        }

        private bool AirDateExists(int id)
        {
            return _context.AirDate.Any(e => e.AirDateId == id);
        }
    }
}
