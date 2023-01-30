namespace Hali.Core.Models
{
    public class ProcessOrder : BaseEntitiy
    {
        public double Price { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
