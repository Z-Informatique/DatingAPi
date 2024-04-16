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
    public class UserimagesController : ControllerBase
    {
        private readonly DatingappContext _context;

        public UserimagesController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Userimages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userimage>>> GetUserimages()
        {
          if (_context.Userimages == null)
          {
              return NotFound();
          }
            return await _context.Userimages.ToListAsync();
        }

        // GET: api/Userimages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userimage>> GetUserimage(int id)
        {
          if (_context.Userimages == null)
          {
              return NotFound();
          }
            var userimage = await _context.Userimages.FindAsync(id);

            if (userimage == null)
            {
                return NotFound();
            }

            return userimage;
        }

        // PUT: api/Userimages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserimage(int id, Userimage userimage)
        {
            if (id != userimage.IduserImage)
            {
                return BadRequest();
            }

            _context.Entry(userimage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserimageExists(id))
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

        // POST: api/Userimages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userimage>> PostUserimage(Userimage userimage)
        {
          if (_context.Userimages == null)
          {
              return Problem("Entity set 'DatingappContext.Userimages'  is null.");
          }
            _context.Userimages.Add(userimage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserimage", new { id = userimage.IduserImage }, userimage);
        }

        // DELETE: api/Userimages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserimage(int id)
        {
            if (_context.Userimages == null)
            {
                return NotFound();
            }
            var userimage = await _context.Userimages.FindAsync(id);
            if (userimage == null)
            {
                return NotFound();
            }

            _context.Userimages.Remove(userimage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserimageExists(int id)
        {
            return (_context.Userimages?.Any(e => e.IduserImage == id)).GetValueOrDefault();
        }
    }
}
