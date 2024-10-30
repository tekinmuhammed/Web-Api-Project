using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .ToTable("customers");
            modelBuilder.Entity<Account>()
            .ToTable("accounts")
            .Property(a => a.AccountId).HasColumnName("account_id");
            modelBuilder.Entity<Card>()
            .ToTable("cards")
            .Property(a => a.AccountId).HasColumnName("account_id");
            modelBuilder.Entity<TransactionType>()
            .ToTable("transactions_types");
            modelBuilder.Entity<Transaction>()
            .ToTable("transactions")
            .Property(a => a.AccountId).HasColumnName("account_id");
        }
    }
}
