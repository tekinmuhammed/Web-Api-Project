namespace WebApplication1.Models
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
