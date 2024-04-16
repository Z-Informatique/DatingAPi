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
    public class UserpassionsController : ControllerBase
    {
        private readonly DatingappContext _context;

        public UserpassionsController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Userpassions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userpassion>>> GetUserpassions()
        {
          if (_context.Userpassions == null)
          {
              return NotFound();
          }
            return await _context.Userpassions.ToListAsync();
        }

        // GET: api/Userpassions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userpassion>> GetUserpassion(int id)
        {
          if (_context.Userpassions == null)
          {
              return NotFound();
          }
            var userpassion = await _context.Userpassions.FindAsync(id);

            if (userpassion == null)
            {
                return NotFound();
            }

            return userpassion;
        }

        // PUT: api/Userpassions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserpassion(int id, Userpassion userpassion)
        {
            if (id != userpassion.IduserPassion)
            {
                return BadRequest();
            }

            _context.Entry(userpassion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserpassionExists(id))
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

        // POST: api/Userpassions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userpassion>> PostUserpassion(Userpassion userpassion)
        {
          if (_context.Userpassions == null)
          {
              return Problem("Entity set 'DatingappContext.Userpassions'  is null.");
          }
            _context.Userpassions.Add(userpassion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserpassion", new { id = userpassion.IduserPassion }, userpassion);
        }

        // DELETE: api/Userpassions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserpassion(int id)
        {
            if (_context.Userpassions == null)
            {
                return NotFound();
            }
            var userpassion = await _context.Userpassions.FindAsync(id);
            if (userpassion == null)
            {
                return NotFound();
            }

            _context.Userpassions.Remove(userpassion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserpassionExists(int id)
        {
            return (_context.Userpassions?.Any(e => e.IduserPassion == id)).GetValueOrDefault();
        }
    }
}
