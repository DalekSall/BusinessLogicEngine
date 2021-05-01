using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Customer Customer { get; set; }
    }
}
