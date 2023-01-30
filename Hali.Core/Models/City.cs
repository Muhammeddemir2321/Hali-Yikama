namespace Hali.Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Town> Townes { get; set; }
    }
}
