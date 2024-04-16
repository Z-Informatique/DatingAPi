using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingAPi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DatingAPi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DatingappContext _context;

        public MessagesController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }
            return await _context.Messages.ToListAsync();
        }

        // Endpoint pour obtenir tous les messages d'une conversation spécifique
        [HttpGet("conversations/{id}/messages")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesForConversation(int id)
        {
            // Vérifier si l'utilisateur a accès à la conversation
            if (!HasAccessToConversation(id))
            {
                return Forbid();
            }

            var messages = await _context.Messages
                .Where(m => m.Idconversation == id)
                .ToListAsync();

            return messages;
        }

        // Endpoint pour envoyer un nouveau message dans une conversation
        [HttpPost("conversations/{id}/messages")]
        public async Task<ActionResult<Message>> SendMessage(int id, [FromBody] Message newMessage)
        {
            // Vérifier si l'utilisateur a accès à la conversation
            if (!HasAccessToConversation(id))
            {
                return Forbid();
            }

            newMessage.Idconversation = id;
            newMessage.Iduser = GetUserIdFromClaims();

            _context.Messages.Add(newMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMessagesForConversation), new { id }, newMessage);
        }


        // Vérifie si l'utilisateur a accès à la conversation
        private bool HasAccessToConversation(int conversationId)
        {
            var userId = GetUserIdFromClaims();

            return _context.Userconversations
                .Any(uc => uc.Iduser == userId && uc.Idconversation == conversationId);
        }

        // Obtient l'ID de l'utilisateur à partir des claims de l'authentification
        private int GetUserIdFromClaims()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null && int.TryParse(claim.Value, out int userId))
            {
                return userId;
            }

            throw new InvalidOperationException("Unable to retrieve user ID from claims.");
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // PUT: api/Messages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(int id, Message message)
        {
            if (id != message.Idmessage)
            {
                return BadRequest();
            }

            _context.Entry(message).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
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

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
          if (_context.Messages == null)
          {
              return Problem("Entity set 'DatingappContext.Messages'  is null.");
          }
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessage", new { id = message.Idmessage }, message);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(int id)
        {
            return (_context.Messages?.Any(e => e.Idmessage == id)).GetValueOrDefault();
        }
    }
}
