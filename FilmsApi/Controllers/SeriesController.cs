using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmsApi.Models;

namespace FilmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SeriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeriesDto>>> GetSeriesVar()
        {
          if (_context.SeriesVar == null)
          {
              return NotFound();
          }
            return await _context.SeriesVar.ToListAsync();
        }

        // GET: api/Series/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeriesDto>> GetSeries(int id)
        {
          if (_context.SeriesVar == null)
          {
              return NotFound();
          }
            var series = await _context.SeriesVar.FindAsync(id);

            if (series == null)
            {
                return NotFound();
            }

            return series;
        }

        // PUT: api/Series/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeries(int id, SeriesDto series)
        {
            if (id != series.Id)
            {
                return BadRequest();
            }

            _context.Entry(series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(id))
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

        // POST: api/Series
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeriesDto>> PostSeries(SeriesDto series)
        {
          if (_context.SeriesVar == null)
          {
              return Problem("Entity set 'AppDbContext.SeriesVar'  is null.");
          }
            _context.SeriesVar.Add(series);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeries", new { id = series.Id }, series);
        }

        // DELETE: api/Series/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeries(int id)
        {
            if (_context.SeriesVar == null)
            {
                return NotFound();
            }
            var series = await _context.SeriesVar.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }

            _context.SeriesVar.Remove(series);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeriesExists(int id)
        {
            return (_context.SeriesVar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
