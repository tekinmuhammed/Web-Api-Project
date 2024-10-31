using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TransactionRepository : ITransactionService
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByAccountIdAsync(int accountId) =>
            await _context.Transactions.Where(t => t.AccountId == accountId).ToListAsync();

        public async Task<Transaction?> GetTransactionByIdAsync(int id) =>
            await _context.Transactions.FindAsync(id);

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
