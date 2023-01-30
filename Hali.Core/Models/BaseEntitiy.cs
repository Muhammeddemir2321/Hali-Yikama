namespace Hali.Core.Models
{
    public abstract class BaseEntitiy
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //public string CreatedUserId { get; set; }
    }
}
