using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetCardsByAccountIdAsync(int accountId);
        Task<Card?> GetCardByIdAsync(int id);
        Task CreateCardAsync(Card card);
        Task UpdateCardAsync(Card card);
        Task DeactivateCardAsync(int id);
        Task ActivateCardAsync(int id);
    }
}
