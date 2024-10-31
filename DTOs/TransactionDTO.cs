namespace WebApplication1.DTOs
{
    public class TransactionDTO
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Description { get; set; }
    }
}
