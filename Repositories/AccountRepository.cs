using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class AccountRepository : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync() =>
            await _context.Accounts.ToListAsync();

        public async Task<Account?> GetAccountByIdAsync(int id) =>
            await _context.Accounts.FindAsync(id);

        public async Task CreateAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                account.AccountStatus = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivateAccountAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                account.AccountStatus = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
