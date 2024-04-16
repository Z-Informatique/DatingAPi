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
    public class PassionsController : ControllerBase
    {
        private readonly DatingappContext _context;

        public PassionsController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Passions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passion>>> GetPassions()
        {
          if (_context.Passions == null)
          {
              return NotFound();
          }
            return await _context.Passions.ToListAsync();
        }

        // GET: api/Passions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passion>> GetPassion(int id)
        {
          if (_context.Passions == null)
          {
              return NotFound();
          }
            var passion = await _context.Passions.FindAsync(id);

            if (passion == null)
            {
                return NotFound();
            }

            return passion;
        }

        // PUT: api/Passions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassion(int id, Passion passion)
        {
            if (id != passion.Idpassion)
            {
                return BadRequest();
            }

            _context.Entry(passion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassionExists(id))
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

        // POST: api/Passions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passion>> PostPassion(Passion passion)
        {
          if (_context.Passions == null)
          {
              return Problem("Entity set 'DatingappContext.Passions'  is null.");
          }
            _context.Passions.Add(passion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassion", new { id = passion.Idpassion }, passion);
        }

        // DELETE: api/Passions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassion(int id)
        {
            if (_context.Passions == null)
            {
                return NotFound();
            }
            var passion = await _context.Passions.FindAsync(id);
            if (passion == null)
            {
                return NotFound();
            }

            _context.Passions.Remove(passion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassionExists(int id)
        {
            return (_context.Passions?.Any(e => e.Idpassion == id)).GetValueOrDefault();
        }
    }
}
