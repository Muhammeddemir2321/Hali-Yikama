namespace Hali.Core.DTOs
{
    public class OrderWithProcessOrderDto : OrderDto
    {
        public List<ProcessOrderDto> ProcessOrders { get; set; }
    }
}
