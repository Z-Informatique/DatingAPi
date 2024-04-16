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
    public class UserabonnementsController : ControllerBase
    {
        private readonly DatingappContext _context;

        public UserabonnementsController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Userabonnements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userabonnement>>> GetUserabonnements()
        {
          if (_context.Userabonnements == null)
          {
              return NotFound();
          }
            return await _context.Userabonnements.ToListAsync();
        }

        // GET: api/Userabonnements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userabonnement>> GetUserabonnement(int id)
        {
          if (_context.Userabonnements == null)
          {
              return NotFound();
          }
            var userabonnement = await _context.Userabonnements.FindAsync(id);

            if (userabonnement == null)
            {
                return NotFound();
            }

            return userabonnement;
        }

        // PUT: api/Userabonnements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserabonnement(int id, Userabonnement userabonnement)
        {
            if (id != userabonnement.IduserAbonnement)
            {
                return BadRequest();
            }

            _context.Entry(userabonnement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserabonnementExists(id))
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

        // POST: api/Userabonnements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userabonnement>> PostUserabonnement(Userabonnement userabonnement)
        {
          if (_context.Userabonnements == null)
          {
              return Problem("Entity set 'DatingappContext.Userabonnements'  is null.");
          }
            _context.Userabonnements.Add(userabonnement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserabonnement", new { id = userabonnement.IduserAbonnement }, userabonnement);
        }

        // DELETE: api/Userabonnements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserabonnement(int id)
        {
            if (_context.Userabonnements == null)
            {
                return NotFound();
            }
            var userabonnement = await _context.Userabonnements.FindAsync(id);
            if (userabonnement == null)
            {
                return NotFound();
            }

            _context.Userabonnements.Remove(userabonnement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserabonnementExists(int id)
        {
            return (_context.Userabonnements?.Any(e => e.IduserAbonnement == id)).GetValueOrDefault();
        }
    }
}
