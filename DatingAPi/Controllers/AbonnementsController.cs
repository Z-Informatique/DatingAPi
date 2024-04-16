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
    public class AbonnementsController : ControllerBase
    {
        private readonly DatingappContext _context;

        public AbonnementsController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Abonnements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonnement>>> GetAbonnements()
        {
          if (_context.Abonnements == null)
          {
              return NotFound();
          }
            return await _context.Abonnements.ToListAsync();
        }

        // GET: api/Abonnements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Abonnement>> GetAbonnement(int id)
        {
          if (_context.Abonnements == null)
          {
              return NotFound();
          }
            var abonnement = await _context.Abonnements.FindAsync(id);

            if (abonnement == null)
            {
                return NotFound();
            }

            return abonnement;
        }

        // PUT: api/Abonnements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbonnement(int id, Abonnement abonnement)
        {
            if (id != abonnement.Idabonnement)
            {
                return BadRequest();
            }

            _context.Entry(abonnement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonnementExists(id))
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

        // POST: api/Abonnements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Abonnement>> PostAbonnement(Abonnement abonnement)
        {
          if (_context.Abonnements == null)
          {
              return Problem("Entity set 'DatingappContext.Abonnements'  is null.");
          }
            _context.Abonnements.Add(abonnement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbonnement", new { id = abonnement.Idabonnement }, abonnement);
        }

        // DELETE: api/Abonnements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbonnement(int id)
        {
            if (_context.Abonnements == null)
            {
                return NotFound();
            }
            var abonnement = await _context.Abonnements.FindAsync(id);
            if (abonnement == null)
            {
                return NotFound();
            }

            _context.Abonnements.Remove(abonnement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AbonnementExists(int id)
        {
            return (_context.Abonnements?.Any(e => e.Idabonnement == id)).GetValueOrDefault();
        }
    }
}
