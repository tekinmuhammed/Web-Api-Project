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
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GetTransactions: Retrieve all transactions or transactions for a specific customer/account/card
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(int? accountId = null, int? cardId = null)
        {
            var transactions = _context.Transactions.AsQueryable();

            if (accountId.HasValue)
            {
                transactions = transactions.Where(t => t.AccountId == accountId.Value);
            }
            if (cardId.HasValue)
            {
                transactions = transactions.Where(t => t.CardId == cardId.Value);
            }

            return await transactions.ToListAsync();
        }

        // AddTransaction: Add a transaction to an account or card
        [HttpPost]
        public async Task<ActionResult<Transaction>> AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransactions), new { id = transaction.TransactionId }, transaction);
        }

        // TransferBetweenAccounts: Transfer funds between two accounts
        [HttpPost("transfer")]
        public async Task<IActionResult> TransferBetweenAccounts(int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _context.Accounts.FindAsync(fromAccountId);
            var toAccount = await _context.Accounts.FindAsync(toAccountId);

            if (fromAccount == null || toAccount == null || fromAccount.Balance < amount)
            {
                return BadRequest("Invalid transaction details.");
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("MakeCardPayment")]
        public async Task<IActionResult> MakeCardPayment(int cardId, decimal amount)
        {
            var card = await _context.Cards.Include(c => c.Account).FirstOrDefaultAsync(c => c.CardId == cardId);

            if (card == null || card.Account == null)
            {
                return NotFound("Card or associated account not found.");
            }

            var customerId = card.Account.CustomerId;
            var customer = await _context.Customers.FindAsync(customerId);

            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

    // Perform payment logic, including updating risk limit or balance
    // Example: Check if amount exceeds the available credit limit
            if (customer.RiskLimit < amount)
            {
                return BadRequest("Insufficient credit limit.");
            }

            // Deduct the amount from the customer's risk limit
            customer.RiskLimit -= amount;

            // Update the database with the transaction
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return Ok("Payment successful.");
        }
    }
}
