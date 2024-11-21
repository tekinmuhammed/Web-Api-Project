using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GetAccounts: Get all accounts or accounts of a specific customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts(int? CustomerId = null)
        {
            if (CustomerId.HasValue)
            {
                return await _context.Accounts.Where(a => a.CustomerId == CustomerId.Value).ToListAsync();
            }
            return await _context.Accounts.ToListAsync();
        }

        // GetAccountById: Get details of a single account by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        // CreateAccount: Create a new account
        [HttpPost]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccountById), new { id = account.AccountId }, account);
        }

        // UpdateAccount: Update an existing account
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(int id, Account account)
        {
            if (id != account.AccountId)
            {
                return BadRequest();
            }
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DeactivateAccount: Deactivate an account and all associated cards
        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            account.AccountStatus = false;
            var cards = _context.Cards.Where(c => c.AccountId == id);
            foreach (var card in cards)
            {
                card.CardStatus = false;
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ActivateAccount: Activate an account without activating associated cards
        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            account.AccountStatus = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}