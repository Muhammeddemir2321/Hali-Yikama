using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection <Order> Orders { get; set; }
    }
}
