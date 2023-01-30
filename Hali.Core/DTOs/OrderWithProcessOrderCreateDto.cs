namespace Hali.Core.DTOs
{
    public class OrderWithProcessOrderCreateDto : ProcessOrderCreateDto
    {
        public int Code { get; set; }
        public string Note { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
    }
}
