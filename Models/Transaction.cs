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
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public required Account Account { get; set; }
        public required Card Card { get; set; }
        public required TransactionType TransactionType { get; set; }
    }
}
