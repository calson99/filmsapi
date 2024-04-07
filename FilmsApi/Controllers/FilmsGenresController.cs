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
    public class FilmsGenresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmsGenresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FilmsGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmsGenres>>> GetFilmsGenres()
        {
          if (_context.FilmsGenres == null)
          {
              return NotFound();
          }
            return await _context.FilmsGenres.ToListAsync();
        }

        // GET: api/FilmsGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmsGenres>> GetFilmsGenres(int id)
        {
          if (_context.FilmsGenres == null)
          {
              return NotFound();
          }
            var filmsGenres = await _context.FilmsGenres.FindAsync(id);

            if (filmsGenres == null)
            {
                return NotFound();
            }

            return filmsGenres;
        }

        // PUT: api/FilmsGenres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmsGenres(int id, FilmsGenres filmsGenres)
        {
            if (id != filmsGenres.FilmsId)
            {
                return BadRequest();
            }

            _context.Entry(filmsGenres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmsGenresExists(id))
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

        // POST: api/FilmsGenres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmsGenres>> PostFilmsGenres(FilmsGenres filmsGenres)
        {
          if (_context.FilmsGenres == null)
          {
              return Problem("Entity set 'AppDbContext.FilmsGenres'  is null.");
          }
            _context.FilmsGenres.Add(filmsGenres);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilmsGenresExists(filmsGenres.FilmsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFilmsGenres", new { id = filmsGenres.FilmsId }, filmsGenres);
        }

        // DELETE: api/FilmsGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmsGenres(int id)
        {
            if (_context.FilmsGenres == null)
            {
                return NotFound();
            }
            var filmsGenres = await _context.FilmsGenres.FindAsync(id);
            if (filmsGenres == null)
            {
                return NotFound();
            }

            _context.FilmsGenres.Remove(filmsGenres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmsGenresExists(int id)
        {
            return (_context.FilmsGenres?.Any(e => e.FilmsId == id)).GetValueOrDefault();
        }
    }
}
