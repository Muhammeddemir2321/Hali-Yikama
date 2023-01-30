namespace Hali.Core.DTOs
{
    public class ProcessOrderDto : BaseDto
    {
        public double Price { get; set; }
        public int ProcessId { get; set; }
        public int OrderId { get; set; }
    }
}
