namespace WebApplication1.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Iban { get; set; }
        public decimal Balance { get; set; } = 0.00M;
        public bool AccountStatus { get; set; } = true;

        public Customer Customer { get; set; }
        public List<Card> Cards { get; set; }
    }
}
