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
    public class FilmsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Films
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmsDto>>> GetFilmsVar()
        {
          if (_context.FilmsVar == null)
          {
              return NotFound();
          }
            return await _context.FilmsVar.ToListAsync();
        }

        // GET: api/Films/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmsDto>> GetFilms(int id)
        {
          if (_context.FilmsVar == null)
          {
              return NotFound();
          }
            var films = await _context.FilmsVar.FindAsync(id);

            if (films == null)
            {
                return NotFound();
            }

            return films;
        }

        // PUT: api/Films/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilms(int id, FilmsDto films)
        {
            if (id != films.Id)
            {
                return BadRequest();
            }

            _context.Entry(films).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsExists(id))
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

        // POST: api/Films
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmsDto>> PostFilms(FilmsDto films)
        {
          if (_context.FilmsVar == null)
          {
              return Problem("Entity set 'AppDbContext.FilmsVar'  is null.");
          }
            _context.FilmsVar.Add(films);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilms", new { id = films.Id }, films);
        }

        // DELETE: api/Films/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilms(int id)
        {
            if (_context.FilmsVar == null)
            {
                return NotFound();
            }
            var films = await _context.FilmsVar.FindAsync(id);
            if (films == null)
            {
                return NotFound();
            }

            _context.FilmsVar.Remove(films);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsExists(int id)
        {
            return (_context.FilmsVar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
