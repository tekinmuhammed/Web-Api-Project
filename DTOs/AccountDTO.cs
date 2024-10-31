namespace WebApplication1.DTOs
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountNumber { get; set; }
        public string? Iban { get; set; }
        public decimal Balance { get; set; }
        public bool AccountStatus { get; set; }
    }
}
