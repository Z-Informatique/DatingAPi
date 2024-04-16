using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DatingAPi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAPi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly DatingappContext _context;

        public ConversationsController(DatingappContext context)
        {
            _context = context;
        }

        // GET: api/Conversations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conversation>>> GetConversations()
        {
            if (_context.Conversations == null)
            {
                return NotFound();
            }
            return await _context.Conversations.ToListAsync();
        }

        // Endpoint pour obtenir toutes les conversations d'un utilisateur
        //[HttpGet("utilisateurs/{userId}/conversations")]
        //public async Task<ActionResult<IEnumerable<Conversation>>> GetConversationsForUser(int userId)
        //{
        //    // Vérifier si l'utilisateur a accès à ces conversations
        //    if (!HasAccessToUser(userId))
        //    {
        //        return Forbid();
        //    }

        //    var conversations = await _context.Conversations
        //        .Where(c => c.Userconversations.Any(uc => uc.Iduser == userId))
        //        .ToListAsync();

        //    return conversations;
        //}


        // GET: api/Conversations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conversation>> GetConversation(int id)
        {
            if (_context.Conversations == null)
            {
                return NotFound();
            }
            var conversation = await _context.Conversations.FindAsync(id);

            if (conversation == null)
            {
                return NotFound();
            }

            return conversation;
        }

        // PUT: api/Conversations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversation(int id, Conversation conversation)
        {
            if (id != conversation.Idconversation)
            {
                return BadRequest();
            }

            _context.Entry(conversation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversationExists(id))
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

        // Endpoint pour créer une nouvelle conversation
        //[HttpPost("conversations")]
        //public async Task<ActionResult<Conversation>> CreateConversation([FromBody] Conversation newConversation)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    // Vérifier si l'utilisateur a accès à tous les utilisateurs de la conversation
        //    foreach (var userId in newConversation.Users.Select(u => u.Idusers))
        //    {
        //        if (!HasAccessToUser(userId))
        //        {
        //            return Forbid();
        //        }
        //    }

        //    _context.Conversations.Add(newConversation);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetConversationsForUser), new { userId = newConversation.ID_utilisateur }, newConversation);
        //}

        // POST: api/Conversations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conversation>> PostConversation(Conversation conversation)
        {
            if (_context.Conversations == null)
            {
                return Problem("Entity set 'DatingappContext.Conversations'  is null.");
            }
            _context.Conversations.Add(conversation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConversation", new { id = conversation.Idconversation }, conversation);
        }

        // Vérifier si l'utilisateur a accès à un autre utilisateur
        private bool HasAccessToUser(int userId)
        {
            var currentUser = GetUserIdFromClaims();
            return userId == currentUser;
        }

        // Obtient l'ID de l'utilisateur à partir des claims de l'authentification
        private int GetUserIdFromClaims()
        {
            var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null && int.TryParse(claim.Value, out int userId))
            {
                return userId;
            }

            throw new InvalidOperationException("Impossible de récupérer l'ID de l'utilisateur à partir des claims.");
        }


        // DELETE: api/Conversations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConversation(int id)
        {
            if (_context.Conversations == null)
            {
                return NotFound();
            }
            var conversation = await _context.Conversations.FindAsync(id);
            if (conversation == null)
            {
                return NotFound();
            }

            _context.Conversations.Remove(conversation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConversationExists(int id)
        {
            return (_context.Conversations?.Any(e => e.Idconversation == id)).GetValueOrDefault();
        }
    }
}
