using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account?> GetAccountByIdAsync(int id);
        Task CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeactivateAccountAsync(int id);
        Task ActivateAccountAsync(int id);
    }
}
