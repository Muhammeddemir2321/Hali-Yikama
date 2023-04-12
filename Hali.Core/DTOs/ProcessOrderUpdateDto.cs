using Hali.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.DTOs
{
    public class ProcessOrderUpdateDto 
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int ProcessId { get; set; }
        public int OrderId { get; set; }
    }
}
