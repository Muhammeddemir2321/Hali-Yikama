namespace Hali.Core.DTOs
{
    public class OrderWithProcessOrdersDto : OrderDto
    {
        public List<ProcessOrderDto> ProcessOrders { get; set; } 
    }
}
