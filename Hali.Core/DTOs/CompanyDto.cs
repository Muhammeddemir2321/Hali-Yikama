using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.DTOs
{
    public class CompanyDto:BaseDto
    {
        public string Name { get; set; }
        public string ProprietorFullName { get; set; }
        public string Email { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string AddressDescription { get; set; }
    }
}
