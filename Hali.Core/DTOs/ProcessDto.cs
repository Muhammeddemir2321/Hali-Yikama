using Hali.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.DTOs
{
    public class ProcessDto:BaseDto
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool Unit { get; set; }
    }
}
