﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.Models
{
    public class Status:BaseEntitiy
    {
        public string Code { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}