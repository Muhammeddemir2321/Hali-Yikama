namespace Hali.Core.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<District> Districts { get; set; }
    }
}
