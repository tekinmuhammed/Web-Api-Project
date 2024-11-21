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
            // Customers table
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");
                entity.Property(a => a.CustomerId).HasColumnName("customer_id");
                entity.Property(a => a.FullName).HasColumnName("full_name");
                entity.Property(a => a.TcNo).HasColumnName("tc_no");
                entity.Property(a => a.BirthPlace).HasColumnName("birth_place");
                entity.Property(a => a.BirthDate).HasColumnName("birth_date");
                entity.Property(a => a.RiskLimit).HasColumnName("risk_limit");
            });

            // Accounts table
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");
                entity.Property(a => a.AccountId).HasColumnName("account_id");
                entity.Property(a => a.CustomerId).HasColumnName("customer_id");
                entity.Property(a => a.AccountName).HasColumnName("account_name");
                entity.Property(a => a.AccountNumber).HasColumnName("account_number");
                entity.Property(a => a.Iban).HasColumnName("iban");
                entity.Property(a => a.Balance).HasColumnName("balance");
                entity.Property(a => a.AccountStatus).HasColumnName("account_status");
            });

            // Cards table
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("cards");
                entity.Property(c => c.CardId).HasColumnName("card_id");
                entity.Property(c => c.AccountId).HasColumnName("account_id");
                entity.Property(c => c.CardNumber).HasColumnName("card_number");
                entity.Property(c => c.ExpiryMonth).HasColumnName("expiry_month");
                entity.Property(c => c.ExpiryYear).HasColumnName("expiry_year");
                entity.Property(c => c.CcvCode).HasColumnName("ccv_code");
                entity.Property(c => c.CardType).HasColumnName("card_type");
                entity.Property(c => c.CardStatus).HasColumnName("card_status");
            });

            // TransactionTypes table
            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("transaction_types");
                entity.Property(t => t.TransactionTypeId).HasColumnName("transaction_type_id");
                entity.Property(t => t.TransactionTypeName).HasColumnName("account__type_name");
            });

            // Transactions table
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");
                entity.Property(t => t.TransactionId).HasColumnName("transaction_id");
                entity.Property(t => t.AccountId).HasColumnName("account_id");
                entity.Property(t => t.CardId).HasColumnName("card_id");
                entity.Property(t => t.TransactionTypeId).HasColumnName("transaction_type_id");            
                entity.Property(t => t.Amount).HasColumnName("amount");             
                entity.Property(t => t.Description).HasColumnName("description");
            });
        }
    }
}
