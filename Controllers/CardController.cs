using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GetCards: Get all cards or cards linked to a specific account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCards(int? accountId = null)
        {
            if (accountId.HasValue)
            {
                return await _context.Cards.Where(c => c.AccountId == accountId.Value).ToListAsync();
            }
            return await _context.Cards.ToListAsync();
        }

        // GetCardById: Get details of a single card by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCardById(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return card;
        }

        // AddCard: Create a new card for a customer or account
        [HttpPost]
        public async Task<ActionResult<Card>> AddCard(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCardById), new { id = card.CardId }, card);
        }

        // DeactivateCard: Deactivate a card
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            card.CardStatus = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ActivateCard: Activate a card
        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateCard(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            card.CardStatus = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
