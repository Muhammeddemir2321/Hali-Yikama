using Microsoft.AspNetCore.Identity;

namespace Hali.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
