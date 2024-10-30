using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Models
{
    public class Transaction
    {
        [Column("transaction_id")]
        public int TransactionId { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        public int? CardId { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Account Account { get; set; }
        public Card Card { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
