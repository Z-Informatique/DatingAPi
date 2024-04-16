using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingAPi.Models;

namespace DatingAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuartiersController : ControllerBase
    {
        private readonly DatingappContext _context;

        public QuartiersController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Quartiers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quartier>>> GetQuartiers()
        {
          if (_context.Quartiers == null)
          {
              return NotFound();
          }
            return await _context.Quartiers.ToListAsync();
        }

        // GET: api/Quartiers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quartier>> GetQuartier(int id)
        {
          if (_context.Quartiers == null)
          {
              return NotFound();
          }
            var quartier = await _context.Quartiers.FindAsync(id);

            if (quartier == null)
            {
                return NotFound();
            }

            return quartier;
        }

        // PUT: api/Quartiers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuartier(int id, Quartier quartier)
        {
            if (id != quartier.Idquartier)
            {
                return BadRequest();
            }

            _context.Entry(quartier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuartierExists(id))
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

        // POST: api/Quartiers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quartier>> PostQuartier(Quartier quartier)
        {
          if (_context.Quartiers == null)
          {
              return Problem("Entity set 'DatingappContext.Quartiers'  is null.");
          }
            _context.Quartiers.Add(quartier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuartier", new { id = quartier.Idquartier }, quartier);
        }

        // DELETE: api/Quartiers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuartier(int id)
        {
            if (_context.Quartiers == null)
            {
                return NotFound();
            }
            var quartier = await _context.Quartiers.FindAsync(id);
            if (quartier == null)
            {
                return NotFound();
            }

            _context.Quartiers.Remove(quartier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuartierExists(int id)
        {
            return (_context.Quartiers?.Any(e => e.Idquartier == id)).GetValueOrDefault();
        }
    }
}
