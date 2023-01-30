namespace Hali.Core.Models
{
    public class Status : BaseEntitiy
    {
        public string Code { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
