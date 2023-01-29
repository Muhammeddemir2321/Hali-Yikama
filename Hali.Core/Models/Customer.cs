﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.Models
{
    public class Customer: BaseEntitiy
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string AddressDescription { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
