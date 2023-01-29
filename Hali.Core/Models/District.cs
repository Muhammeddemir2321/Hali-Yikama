using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.Models
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TownId { get; set; }
        public Town Town { get; set; }
    }
}
