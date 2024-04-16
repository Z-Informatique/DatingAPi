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
    public class UserlikeprofilsController : ControllerBase
    {
        private readonly DatingappContext _context;

        public UserlikeprofilsController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Userlikeprofils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userlikeprofil>>> GetUserlikeprofils()
        {
          if (_context.Userlikeprofils == null)
          {
              return NotFound();
          }
            return await _context.Userlikeprofils.ToListAsync();
        }

        // GET: api/Userlikeprofils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userlikeprofil>> GetUserlikeprofil(int id)
        {
          if (_context.Userlikeprofils == null)
          {
              return NotFound();
          }
            var userlikeprofil = await _context.Userlikeprofils.FindAsync(id);

            if (userlikeprofil == null)
            {
                return NotFound();
            }

            return userlikeprofil;
        }

        // PUT: api/Userlikeprofils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserlikeprofil(int id, Userlikeprofil userlikeprofil)
        {
            if (id != userlikeprofil.IduserLikeProfil)
            {
                return BadRequest();
            }

            _context.Entry(userlikeprofil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserlikeprofilExists(id))
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

        // POST: api/Userlikeprofils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userlikeprofil>> PostUserlikeprofil(Userlikeprofil userlikeprofil)
        {
          if (_context.Userlikeprofils == null)
          {
              return Problem("Entity set 'DatingappContext.Userlikeprofils'  is null.");
          }
            _context.Userlikeprofils.Add(userlikeprofil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserlikeprofil", new { id = userlikeprofil.IduserLikeProfil }, userlikeprofil);
        }

        // DELETE: api/Userlikeprofils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserlikeprofil(int id)
        {
            if (_context.Userlikeprofils == null)
            {
                return NotFound();
            }
            var userlikeprofil = await _context.Userlikeprofils.FindAsync(id);
            if (userlikeprofil == null)
            {
                return NotFound();
            }

            _context.Userlikeprofils.Remove(userlikeprofil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserlikeprofilExists(int id)
        {
            return (_context.Userlikeprofils?.Any(e => e.IduserLikeProfil == id)).GetValueOrDefault();
        }
    }
}
