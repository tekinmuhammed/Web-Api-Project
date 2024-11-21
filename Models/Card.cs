namespace WebApplication1.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public int AccountId { get; set; }
        public string? CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public string? CcvCode { get; set; }
        public string? CardType { get; set; }
        public bool CardStatus { get; set; } = true;

        public required Account Account { get; set; }
    }
}