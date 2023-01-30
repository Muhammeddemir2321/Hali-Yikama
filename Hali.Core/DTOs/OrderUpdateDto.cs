using Hali.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hali.Core.DTOs
{
    public class OrderUpdateDto
    {
        public int id { get; set; }
        public int Code { get; set; }
        public string Note { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
    }
}
