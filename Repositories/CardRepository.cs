using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CardRepository : ICardService
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetCardsByAccountIdAsync(int accountId) =>
            await _context.Cards.Where(c => c.AccountId == accountId).ToListAsync();

        public async Task<Card?> GetCardByIdAsync(int id) =>
            await _context.Cards.FindAsync(id);

        public async Task CreateCardAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCardAsync(Card card)
        {
            _context.Entry(card).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateCardAsync(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                card.CardStatus = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivateCardAsync(int id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                card.CardStatus = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
