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
    public class GenresSeriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenresSeriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/GenresSeries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenresSeries>>> GetGenresSeries()
        {
          if (_context.GenresSeries == null)
          {
              return NotFound();
          }
            return await _context.GenresSeries.ToListAsync();
        }

        // GET: api/GenresSeries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenresSeries>> GetGenresSeries(int id)
        {
          if (_context.GenresSeries == null)
          {
              return NotFound();
          }
            var genresSeries = await _context.GenresSeries.FindAsync(id);

            if (genresSeries == null)
            {
                return NotFound();
            }

            return genresSeries;
        }

        // PUT: api/GenresSeries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenresSeries(int id, GenresSeries genresSeries)
        {
            if (id != genresSeries.GenresId)
            {
                return BadRequest();
            }

            _context.Entry(genresSeries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenresSeriesExists(id))
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

        // POST: api/GenresSeries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenresSeries>> PostGenresSeries(GenresSeries genresSeries)
        {
          if (_context.GenresSeries == null)
          {
              return Problem("Entity set 'AppDbContext.GenresSeries'  is null.");
          }
            _context.GenresSeries.Add(genresSeries);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GenresSeriesExists(genresSeries.GenresId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGenresSeries", new { id = genresSeries.GenresId }, genresSeries);
        }

        // DELETE: api/GenresSeries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenresSeries(int id)
        {
            if (_context.GenresSeries == null)
            {
                return NotFound();
            }
            var genresSeries = await _context.GenresSeries.FindAsync(id);
            if (genresSeries == null)
            {
                return NotFound();
            }

            _context.GenresSeries.Remove(genresSeries);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenresSeriesExists(int id)
        {
            return (_context.GenresSeries?.Any(e => e.GenresId == id)).GetValueOrDefault();
        }
    }
}
