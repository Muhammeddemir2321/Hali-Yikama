namespace Hali.Core.DTOs
{
    public class OrderDto : BaseDto
    {
        public int Code { get; set; }
        public string Note { get; set; }
        public bool TotalPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
    }
}
