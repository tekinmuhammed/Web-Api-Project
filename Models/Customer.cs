namespace WebApplication1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public string? TcNo { get; set; }
        public string? BirthPlace { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal RiskLimit { get; set; } = 10000.00M;

        public required List<Account> Accounts { get; set; }
    }
}
