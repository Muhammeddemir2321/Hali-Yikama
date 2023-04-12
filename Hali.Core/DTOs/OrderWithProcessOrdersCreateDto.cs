namespace Hali.Core.DTOs
{
    public class OrderWithProcessOrdersCreateDto
    {
        public List<ProcessOrderCreateDto> ProcessOrders { get; set; } 
        public int Code { get; set; }
        public string Note { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
    }
}
