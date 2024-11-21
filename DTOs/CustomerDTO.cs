namespace WebApplication1.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public decimal RiskLimit { get; set; }
    }
}
