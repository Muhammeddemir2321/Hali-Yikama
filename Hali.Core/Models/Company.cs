namespace Hali.Core.Models
{
    public class Company : BaseEntitiy
    {
        public string Name { get; set; }
        public string ProprietorFullName { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string AddressDescription { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
