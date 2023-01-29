namespace Hali.Core.Models
{
    public class Order:BaseEntitiy
    {
        public int Code { get; set; }
        public string Note { get; set; }
        public bool TotalPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<ProcessOrder> ProcessOrders { get; set; }
    }
}
