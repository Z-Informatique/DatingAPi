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
    public class PaysController : ControllerBase
    {
        private readonly DatingappContext _context;

        public PaysController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Pays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pay>>> GetPays()
        {
          if (_context.Pays == null)
          {
              return NotFound();
          }
            return await _context.Pays.ToListAsync();
        }

        // GET: api/Pays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pay>> GetPay(int id)
        {
          if (_context.Pays == null)
          {
              return NotFound();
          }
            var pay = await _context.Pays.FindAsync(id);

            if (pay == null)
            {
                return NotFound();
            }

            return pay;
        }

        // PUT: api/Pays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPay(int id, Pay pay)
        {
            if (id != pay.Idpays)
            {
                return BadRequest();
            }

            _context.Entry(pay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayExists(id))
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

        // POST: api/Pays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pay>> PostPay(Pay pay)
        {
          if (_context.Pays == null)
          {
              return Problem("Entity set 'DatingappContext.Pays'  is null.");
          }
            _context.Pays.Add(pay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPay", new { id = pay.Idpays }, pay);
        }

        // DELETE: api/Pays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePay(int id)
        {
            if (_context.Pays == null)
            {
                return NotFound();
            }
            var pay = await _context.Pays.FindAsync(id);
            if (pay == null)
            {
                return NotFound();
            }

            _context.Pays.Remove(pay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayExists(int id)
        {
            return (_context.Pays?.Any(e => e.Idpays == id)).GetValueOrDefault();
        }
    }
}
