using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.Models
{
    public class Process: BaseEntitiy
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool Unit { get; set; }
        public ICollection<ProcessOrder> ProcessOrders { get; set; }
    }
}
