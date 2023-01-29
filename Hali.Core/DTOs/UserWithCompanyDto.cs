using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.DTOs
{
    public class UserWithCompanyDto:AppUserDto
    {
        public CompanyDto Company { get; set; }
    }
}
